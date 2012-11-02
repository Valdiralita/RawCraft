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
            RenderFIFO.Enqueue(this);
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

        public void EnqueueToRender()
        {
            RenderFIFO.Enqueue(this);
        }

        public void ChangeBlock(Vector3 pos, byte id, byte metadata, bool suppressRendering)
        {
            BlockType[(int)pos.X, (int)pos.Y, (int)pos.Z] = id;
            BlockMetadata[(int)pos.X, (int)pos.Y, (int)pos.Z] = metadata;
            if (!suppressRendering)
                RenderFIFO.Enqueue(this);
        }
    }
}

