using System.Linq;
using RawCraft.Renderer;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RawCraft.Storage.Map
{
    public class Chunk
    {
        public readonly int ChunkX;
        public readonly int ChunkZ;
        public byte[, ,] BlockType = new byte[16, 256, 16];
        public byte[, ,] BlockMetadata = new byte[16, 256, 16];

        private Mesh _opaqueMesh, _waterMesh;

        public Chunk(int x, int z, int sections, ushort primBit, byte[] chunk)
        {
            ChunkX = x;
            ChunkZ = z;

            SetChunk(primBit, chunk, sections);
            RenderFIFO.Enqueue(this, new[] { true, true, true, true });
        }

        internal void SetChunk(ushort primBit, byte[] data, int sections)
        {
            int sectionCounter = 0;
            int x = 0, y = 0, z = 0;
            for (int i = 0; i < 16; i++)
            {
                if ((primBit & 1 << i) == 1 << i)
                {
                    byte[] id = data.Skip(sectionCounter * 4096).Take(4096).ToArray();
                    byte[] meta = data.Skip(sections * 4096 + sectionCounter * 2048).Take(2048).ToArray();
                    for (int j = 0; j < 4096; j++)
                    {
                        BlockType[x, y, z] = id[j];
                        if (meta[j / 2] != 0 && j % 2 == 0)
                        {
                            BlockMetadata[x + 1, y, z] = (byte)((meta[j / 2] & 0xf0) >> 4);
                            BlockMetadata[x, y, z] = (byte)(meta[j / 2] & 0x0f);
                        }
                        x++;
                        if (x > 15)
                        {
                            x = 0;
                            z++;
                            if (z > 15)
                            {
                                z = 0;
                                y++;
                                if (y > 255)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    sectionCounter++;
                }
            }
        }

        public void DrawOpaque(Effect effect)
        {
            if (_opaqueMesh != null)
                _opaqueMesh.Draw(effect);
        }
        public void DrawWater(Effect effect)
        {
            if (_waterMesh != null)
                _waterMesh.Draw(effect);
        }

        public void UpdateMesh(GraphicsDevice gd)
        {
            Mesh[] meshes = VertexIndexGenerator.Generate(this, gd);

            if (meshes != null)
            {
                if (meshes.Length > 0)
                    _opaqueMesh = meshes[0];

                if (meshes.Length > 1)
                    _waterMesh = meshes[1];
            }
        }

        public void EnqueueToRender(bool[] toRender)
        {
            RenderFIFO.Enqueue(this, toRender);
        }

        public void ChangeBlock(Vector3 pos, byte id, byte metadata, bool supressRerender)
        {
            BlockType[(int)pos.X, (int)pos.Y, (int)pos.Z] = id;
            BlockMetadata[(int)pos.X, (int)pos.Y, (int)pos.Z] = metadata;
            if (!supressRerender)
            {
                RenderFIFO.Enqueue(this, new[] { 
                    (int)pos.X == 15, 
                    (int)pos.X == 0, 
                    (int)pos.Y == 15, 
                    (int)pos.Y == 0 
                });
            }
        }
        public void MultiBlockChange(byte[][] data, int count)
        {
            bool[] toRender = new bool[4];

            for (int i = 0; i < count; i++)
            {
                int offsetX = (data[i][0] >> 4) & 0x0F;
                int offsetZ = data[i][0] & 0x0F;

                byte meta = (byte)(data[i][3] & 0x0F);
                byte id = (byte)((data[i][2] << 4 | (data[i][3] >> 4) & 0x0F));
                ChangeBlock(new Vector3(offsetX, data[i][1], offsetZ), id, meta, true);

                if (!toRender[0])
                    toRender[0] = offsetX == 15;
                if (!toRender[1])
                    toRender[1] = offsetX == 0; 
                if (!toRender[2])
                    toRender[2] = offsetX == 15;
                if (!toRender[3])
                    toRender[3] = offsetX == 0;
            }
            EnqueueToRender(toRender);
        }
    }
}

