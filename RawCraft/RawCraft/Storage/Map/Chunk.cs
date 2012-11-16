using System.Linq;
using RawCraft.Renderer;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using RawCraft.Network;

namespace RawCraft.Storage.Map
{
    public class Chunk
    {
        public int ChunkX;
        public int ChunkZ;
        public byte[, ,] BlockType = new byte[16, 256, 16];
        public byte[, ,] BlockMetadata = new byte[16, 256, 16];

        private Mesh OpaqueMesh, WaterMesh;

        public Chunk(int X, int Z, int sections, ushort primBit, byte[] Chunk)
        {
            ChunkX = X;
            ChunkZ = Z;

            SetChunk(primBit, Chunk, sections);
            RenderFIFO.Enqueue(this, new bool[4] { true, true, true, true });
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
            if (OpaqueMesh != null)
                OpaqueMesh.Draw(effect);
        }
        public void DrawWater(Effect effect)
        {
            if (WaterMesh != null)
                WaterMesh.Draw(effect);
        }

        public void UpdateMesh(GraphicsDevice gd)
        {
            Mesh[] meshes = VertexIndexGenerator.generate(this, gd);

            if (meshes != null)
            {
                if (meshes.Length > 0)
                    OpaqueMesh = meshes[0];

                if (meshes.Length > 1)
                    WaterMesh = meshes[1];
            }
        }

        public void EnqueueToRender(bool[] toRender)
        {
            RenderFIFO.Enqueue(this, toRender);
        }

        public void ChangeBlock(Vector3 pos, byte id, byte metadata, bool SupressRerender)
        {
            BlockType[(int)pos.X, (int)pos.Y, (int)pos.Z] = id;
            BlockMetadata[(int)pos.X, (int)pos.Y, (int)pos.Z] = metadata;
            if (!SupressRerender)
            {
                RenderFIFO.Enqueue(this, new bool[] { 
                    pos.X == 15 ? true : false, 
                    pos.X == 0 ? true : false, 
                    pos.Y == 15 ? true : false, 
                    pos.Y == 0 ? true : false 
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
                    toRender[0] = offsetX == 15 ? true : false;
                if (!toRender[1])
                    toRender[1] = offsetX == 0 ? true : false; 
                if (!toRender[2])
                    toRender[2] = offsetX == 15 ? true : false;
                if (!toRender[3])
                    toRender[3] = offsetX == 0 ? true : false;
            }
            EnqueueToRender(toRender);
        }
    }
}

