using System.Linq;
using RawCraft.Renderer;

namespace RawCraft.Storage.Map
{
    public class Chunk
    {
        public int ChunkX;
        public int ChunkZ;
        public byte[, ,] BlockType = new byte[16, 256, 16];
        public byte[, ,] BlockMetadata = new byte[16, 256, 16];

        //public byte[, , ,] BlockLight = new byte[16, 16, 16, 16];    // not implemented
        //public byte[, , ,] SkyLight = new byte[16, 16, 16, 16];      // not implemented
        //public byte[,] Biome = new byte[16, 16];                     // not implemented
        ushort PrimBit;
        private Mesh OpaqueMesh, WaterMesh;

        public Chunk(int X, int Z, ushort primBit, byte[] Chunk)
        {
            PrimBit = primBit;
            ChunkX = X;
            ChunkZ = Z;

            int count = 0;
            while (primBit != 0)
            {
                count++;
                primBit &= (ushort)(primBit - 1);
            }

            SetChunk(Chunk, count);
            RenderFIFO.Enqueue(this);
        }

        private void SetChunk(byte[] _Chunk, int sections)
        {
            int sectionCounter = 0;
            int x = 0, y = 0, z = 0;
            for (int i = 0; i < 16; i++)
            {
                if ((PrimBit & 1 << i) == 1 << i)
                {
                    byte[] id = _Chunk.Skip(sectionCounter*4096).Take(4096).ToArray();
                    byte[] meta = _Chunk.Skip(sections * 4096 + sectionCounter * 2048).Take(2048).ToArray();
                    for (int j = 0; j < 4096; j++)
                    {
                        BlockType[x, y, z] = id[j];
                        if (meta[j/2] != 0 && j % 2 == 0)
                        {
                            BlockMetadata[x + 1, y, z] = (byte)((meta[j/2] & 0xf0) >> 4);
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

        public void DrawOpaque()
        {
            if (OpaqueMesh != null)
                OpaqueMesh.Draw();
        }
        public void DrawWater()
        {
            if (WaterMesh != null)
                WaterMesh.Draw();
        }

        public void UpdateMesh()
        {
            Mesh[] meshes = VertexIndexGenerator.generate(this);

            if (meshes != null)
            {
                if (meshes.Length > 0)
                    OpaqueMesh = meshes[0];

                if (meshes.Length > 1)
                    WaterMesh = meshes[1];
            }
        }
    }
}

