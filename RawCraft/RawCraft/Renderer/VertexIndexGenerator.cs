#region Using Statements

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RawCraft.Storage;
using RawCraft.Storage.Blocks;
using RawCraft.Storage.Map;
using Renderer;
using System.Collections.Generic;
using System;

#endregion

namespace RawCraft.Renderer
{
    static class VertexIndexGenerator
    {
        private static List<VertexPositionNormalTexture> OpaqueVertices;
        private static List<int> OpaqueIndices;
        private static List<VertexPositionNormalTexture> TransparentVertices;
        private static List<int> TransparentIndices;

        private static int X, Y, Z;
        private static byte ID, Meta;
        private static Chunk chunk;

        public static Mesh[] generate(Chunk c)
        {
            X = 0;
            Y = 0;
            Z = 0;

            chunk = c;

            OpaqueVertices = new List<VertexPositionNormalTexture>();
            OpaqueIndices = new List<int>();
            TransparentVertices = new List<VertexPositionNormalTexture>();
            TransparentIndices = new List<int>();

            for (; ; X++)
            {
                if (X > 15)
                {
                    Z++;
                    X = 0;
                    if (Z > 15)
                    {
                        Y++;
                        Z = 0;
                        if (Y > 255)
                        {
                            break;
                        }
                    }
                }

                ID = c.BlockType[X, Y, Z];
                Meta = c.BlockMetadata[X, Y, Z];

                if (ID == (int)BlockEnum.Blocks.PistonSticky)
                {

                }

                if (!Blocks.blocks[ID].IsEntity && !Blocks.blocks[ID].IsTransparent)
                {
                    if (!Blocks.blocks[ID].HasMetadata)
                    {
                        if (Blocks.blocks[ID].IsMultitex)
                        {
                            if (isTransparent(0))
                                CreateMultiTexBlockSide(0, 0);
                            if (isTransparent(1))
                                CreateMultiTexBlockSide(1, 1);
                            if (isTransparent(2))
                                CreateMultiTexBlockSide(2, 2);
                            if (isTransparent(3))
                                CreateMultiTexBlockSide(3, 3);
                            if (isTransparent(4))
                                CreateMultiTexBlockSide(4, 4);
                            if (isTransparent(5))
                                CreateMultiTexBlockSide(5, 5);
                        }
                        else
                        {
                            if (isTransparent(0))
                                CreateBlockSide(0);
                            if (isTransparent(1))
                                CreateBlockSide(1);
                            if (isTransparent(2))
                                CreateBlockSide(2);
                            if (isTransparent(3))
                                CreateBlockSide(3);
                            if (isTransparent(4))
                                CreateBlockSide(4);
                            if (isTransparent(5))
                                CreateBlockSide(5);
                        }
                    }
                    else
                    {
                        if (Blocks.blocks[ID].IsMultitex)
                        {
                            if (isTransparent(0))
                                CreateMultiTexBlockSide(0, (byte)(0 + Meta * 6));
                            if (isTransparent(1))
                                CreateMultiTexBlockSide(1, (byte)(1 + Meta * 6));
                            if (isTransparent(2))
                                CreateMultiTexBlockSide(2, (byte)(2 + Meta * 6));
                            if (isTransparent(3))
                                CreateMultiTexBlockSide(3, (byte)(3 + Meta * 6));
                            if (isTransparent(4))
                                CreateMultiTexBlockSide(4, (byte)(4 + Meta * 6));
                            if (isTransparent(5))
                                CreateMultiTexBlockSide(5, (byte)(5 + Meta * 6));
                        }
                        else
                        {
                            if (isTransparent(0))
                                CreateBlockSide(0);
                            if (isTransparent(1))
                                CreateBlockSide(1);
                            if (isTransparent(2))
                                CreateBlockSide(2);
                            if (isTransparent(3))
                                CreateBlockSide(3);
                            if (isTransparent(4))
                                CreateBlockSide(4);
                            if (isTransparent(5))
                                CreateBlockSide(5);
                        }
                    }
                }
                else if (Blocks.blocks[ID].IsEntity)
                {
                    if (ID == 6 || ID == 31 || ID == 32 || ID == 37 || ID == 38 || ID == 39 || ID == 40 || ID == 59 || ID == 83 || ID == 104 || ID == 105 || ID == 115 || ID == 117)
                    {
                        CreatePlant();
                    }
                    else if (ID == 9)//quick hack for water
                    {
                        if (c.BlockType[X, Y + 1, Z] != 9)
                            CreateWater(4);
                    }
                    else if (ID == 79) //ice hack
                    {
                        if (Blocks.blocks[c.BlockType[X, Y, Z + 1]].IsTransparent || Blocks.blocks[c.BlockType[X, Y, Z + 1]].IsEntity)
                            TransparentQuad(0);
                        if (Blocks.blocks[c.BlockType[X, Y, Z - 1]].IsTransparent || Blocks.blocks[c.BlockType[X, Y, Z - 1]].IsEntity)
                            TransparentQuad(1);
                        if (Blocks.blocks[c.BlockType[X + 1, Y, Z]].IsTransparent || Blocks.blocks[c.BlockType[X, Y, Z - 1]].IsEntity)
                            TransparentQuad(2);
                        if (Blocks.blocks[c.BlockType[X - 1, Y, Z]].IsTransparent || Blocks.blocks[c.BlockType[X, Y, Z - 1]].IsEntity)
                            TransparentQuad(3);
                        if (Blocks.blocks[c.BlockType[X, Y + 1, Z]].IsTransparent || Blocks.blocks[c.BlockType[X, Y, Z - 1]].IsEntity)
                            TransparentQuad(4);
                        if (Blocks.blocks[c.BlockType[X, Y - 1, Z]].IsTransparent || Blocks.blocks[c.BlockType[X, Y, Z - 1]].IsEntity)
                            TransparentQuad(5);
                    }
                }
                else if (Blocks.blocks[ID].IsTransparent)
                {
                    if (ID == 18 || ID == 20 || ID == 24)
                    {
                        CreateBlockSide(0);
                        CreateBlockSide(1);
                        CreateBlockSide(2);
                        CreateBlockSide(3);
                        CreateBlockSide(4);
                        CreateBlockSide(5);
                    }
                }
            }

            Mesh[] meshes = new Mesh[2];

            if (OpaqueIndices.Count > 0)
                meshes[0] = new Mesh(OpaqueVertices.ToArray(), OpaqueIndices.ToArray());
            if (TransparentIndices.Count > 0)
                meshes[1] = new Mesh(TransparentVertices.ToArray(), TransparentIndices.ToArray());
            return meshes;
        }

        private static void CreateSlab()
        {
            throw new NotImplementedException();
        }

        private static void CreateBlockSide(byte side)
        {
            Vector2[] tex;

            if (TextureCoordinates.Textures.TryGetValue(Tuple.Create(ID, Meta), out tex))
            {
                CreateQuad(side, tex);
            }
        }

        private static void CreateMultiTexBlockSide(byte side, byte texpos)
        {
            Vector2[] tex;

            if (TextureCoordinates.Textures.TryGetValue(Tuple.Create(ID, texpos), out tex))
            {
                CreateQuad(side, tex);
            }
        }

        private static void CreateQuad(byte side, Vector2[] tex)
        {

            Vector3 positionOffset = new Vector3(16 * chunk.ChunkX + X + 0.5f, Y + 0.5f, Z + 0.5f + 16 * chunk.ChunkZ);

            OpaqueIndices.Add(OpaqueVertices.Count + 1);
            OpaqueIndices.Add(OpaqueVertices.Count + 0);
            OpaqueIndices.Add(OpaqueVertices.Count + 3);

            OpaqueIndices.Add(OpaqueVertices.Count + 1);
            OpaqueIndices.Add(OpaqueVertices.Count + 3);
            OpaqueIndices.Add(OpaqueVertices.Count + 2);

            int i = 0;

            foreach (Vector3 vec in VertexPositions.Block[side])
            {
                OpaqueVertices.Add(new VertexPositionNormalTexture(vec + positionOffset, Misc.normals[side], tex[i]));
                if (++i > 3)
                    i = 0;
            }
        }

        private static void CreatePlant()
        {
            Vector2[] tex;
            if (TextureCoordinates.Textures.TryGetValue(Tuple.Create(ID, Meta), out tex))
            {
                Vector3 positionOffset = new Vector3(16 * chunk.ChunkX + X + 0.5f, Y + 0.5f, Z + 0.5f + 16 * chunk.ChunkZ);

                for (int i = 0; i < 4; i++)
                {
                    OpaqueIndices.Add(OpaqueVertices.Count + 0 + 4 * i);
                    OpaqueIndices.Add(OpaqueVertices.Count + 1 + 4 * i);
                    OpaqueIndices.Add(OpaqueVertices.Count + 2 + 4 * i);
                    OpaqueIndices.Add(OpaqueVertices.Count + 0 + 4 * i);
                    OpaqueIndices.Add(OpaqueVertices.Count + 2 + 4 * i);
                    OpaqueIndices.Add(OpaqueVertices.Count + 3 + 4 * i);
                }

                int j = 0;

                foreach (Vector3 vec in VertexPositions.Plant)
                {
                    OpaqueVertices.Add(new VertexPositionNormalTexture(vec + positionOffset, Vector3.Zero, tex[j]));
                    if (++j > 3)
                        j = 0;
                }
            }
        }

        private static void TransparentQuad(byte side) //todo: update
        {
            Vector2[] tex;
            if (TextureCoordinates.Textures.TryGetValue(Tuple.Create(ID, (byte)0), out tex))
            {
                Vector3 normal = Misc.normals[side];

                Vector3 side1 = new Vector3(normal.Y, normal.Z, normal.X);
                Vector3 side2 = Vector3.Cross(normal, side1);

                Vector3 positionOffset = new Vector3(16 * chunk.ChunkX + X + 0.5f, Y + 0.5f, Z + 0.5f + 16 * chunk.ChunkZ) * 2;

                TransparentIndices.Add(TransparentVertices.Count + 0);
                TransparentIndices.Add(TransparentVertices.Count + 1);
                TransparentIndices.Add(TransparentVertices.Count + 2);

                TransparentIndices.Add(TransparentVertices.Count + 0);
                TransparentIndices.Add(TransparentVertices.Count + 2);
                TransparentIndices.Add(TransparentVertices.Count + 3);

                TransparentVertices.Add(new VertexPositionNormalTexture((normal - side1 - side2 + positionOffset) / 2, normal, tex[0]));
                TransparentVertices.Add(new VertexPositionNormalTexture((normal - side1 + side2 + positionOffset) / 2, normal, tex[1]));
                TransparentVertices.Add(new VertexPositionNormalTexture((normal + side1 + side2 + positionOffset) / 2, normal, tex[2]));
                TransparentVertices.Add(new VertexPositionNormalTexture((normal + side1 - side2 + positionOffset) / 2, normal, tex[3]));
            }
        }

        private static void CreateWater(byte side) //todo: update
        {
            Vector2[] tex;
            if (TextureCoordinates.Textures.TryGetValue(Tuple.Create(ID, (byte)0), out tex))
            {
                Vector3 normal = Misc.normals[side];

                Vector3 side1 = new Vector3(normal.Y, normal.Z, normal.X);
                Vector3 side2 = Vector3.Cross(normal, side1);

                Vector3 positionOffset = new Vector3(16 * chunk.ChunkX + X + 0.5f, Y + 0.4f, Z + 0.5f + 16 * chunk.ChunkZ) * 2;

                TransparentIndices.Add(TransparentVertices.Count + 0);
                TransparentIndices.Add(TransparentVertices.Count + 1);
                TransparentIndices.Add(TransparentVertices.Count + 2);

                TransparentIndices.Add(TransparentVertices.Count + 0);
                TransparentIndices.Add(TransparentVertices.Count + 2);
                TransparentIndices.Add(TransparentVertices.Count + 3);

                TransparentVertices.Add(new VertexPositionNormalTexture((normal - side1 - side2 + positionOffset) / 2, normal, tex[0]));
                TransparentVertices.Add(new VertexPositionNormalTexture((normal - side1 + side2 + positionOffset) / 2, normal, tex[1]));
                TransparentVertices.Add(new VertexPositionNormalTexture((normal + side1 + side2 + positionOffset) / 2, normal, tex[2]));
                TransparentVertices.Add(new VertexPositionNormalTexture((normal + side1 - side2 + positionOffset) / 2, normal, tex[3]));
            }
        }

        private static bool isTransparent(byte side)
        {
            Chunk AdjacentChunk = null;

            switch (side)
            {
                case 0x00: // Z+
                    {
                        if (Z == 15)
                        {
                            if (MapChunks.Chunks.TryGetValue(new Vector2(chunk.ChunkX, chunk.ChunkZ + 1), out AdjacentChunk))
                                if (Blocks.blocks[AdjacentChunk.BlockType[X, Y, 0]].IsTransparent || Blocks.blocks[AdjacentChunk.BlockType[X, Y, 0]].IsEntity)
                                    return true;
                            return false;
                        }
                        else
                        {
                            if (Blocks.blocks[chunk.BlockType[X, Y, Z + 1]].IsTransparent || Blocks.blocks[chunk.BlockType[X, Y, Z + 1]].IsEntity)
                                return true;
                        }
                        return false;
                    }
                case 0x01: // Z-
                    {
                        if (Z == 0)
                        {
                            if (MapChunks.Chunks.TryGetValue(new Vector2(chunk.ChunkX, chunk.ChunkZ - 1), out AdjacentChunk))
                                if (Blocks.blocks[AdjacentChunk.BlockType[X, Y, 15]].IsTransparent || Blocks.blocks[AdjacentChunk.BlockType[X, Y, 15]].IsEntity)
                                    return true;
                            return false;
                        }
                        else
                        {
                            if (Blocks.blocks[chunk.BlockType[X, Y, Z - 1]].IsTransparent || Blocks.blocks[chunk.BlockType[X, Y, Z - 1]].IsEntity)
                                return true;
                        }
                        return false;
                    }
                case 0x02: // X+
                    {
                        if (X == 15)
                        {
                            if (MapChunks.Chunks.TryGetValue(new Vector2(chunk.ChunkX + 1, chunk.ChunkZ), out AdjacentChunk))
                                if (Blocks.blocks[AdjacentChunk.BlockType[0, Y, Z]].IsTransparent || Blocks.blocks[AdjacentChunk.BlockType[0, Y, Z]].IsEntity)
                                    return true;
                            return false;
                        }
                        else
                        {
                            if (Blocks.blocks[chunk.BlockType[X + 1, Y, Z]].IsTransparent || Blocks.blocks[chunk.BlockType[X + 1, Y, Z]].IsEntity)
                                return true;
                        }
                        return false;
                    }
                case 0x03: // X-
                    {
                        if (X == 0)
                        {
                            if (MapChunks.Chunks.TryGetValue(new Vector2(chunk.ChunkX - 1, chunk.ChunkZ), out AdjacentChunk))
                                if (Blocks.blocks[AdjacentChunk.BlockType[15, Y, Z]].IsTransparent || Blocks.blocks[AdjacentChunk.BlockType[15, Y, Z]].IsEntity)
                                    return true;
                            return false;
                        }
                        else
                        {
                            if (Blocks.blocks[chunk.BlockType[X - 1, Y, Z]].IsTransparent || Blocks.blocks[chunk.BlockType[X - 1, Y, Z]].IsEntity)
                                return true;
                        }
                        return false;
                    }
                case 0x04:
                    {
                        if (Y == 255)
                        {
                            return true;
                        }
                        else
                        {
                            if (Blocks.blocks[chunk.BlockType[X, Y + 1, Z]].IsTransparent || Blocks.blocks[chunk.BlockType[X, Y + 1, Z]].IsEntity)
                                return true;
                        }
                        return false;
                    }
                case 0x05:
                    {
                        if (Y == 0)
                        {
                            return false;
                        }
                        else
                        {
                            if (Blocks.blocks[chunk.BlockType[X, Y - 1, Z]].IsEntity || Blocks.blocks[chunk.BlockType[X, Y - 1, Z]].IsTransparent)
                                return true;
                        }
                        return false;
                    }
                default:
                    throw new Exception();
            }
        }
    }
}




// if (side == 2 || side == 3)
// {
//  OpaqueVertices.Add(new VertexPositionNormalTexture((normal - side1 + side2 + position_offset) / 2, normal, Texture[1]));
//  OpaqueVertices.Add(new VertexPositionNormalTexture((normal - side1 + side2 + position_offset) / 2, normal, Texture[2]));
//  OpaqueVertices.Add(new VertexPositionNormalTexture((normal + side1 + side2 + position_offset) / 2, normal, Texture[3]));
//  OpaqueVertices.Add(new VertexPositionNormalTexture((normal + side1 - side2 + position_offset) / 2, normal, Texture[0]));
// }
// else if (side == 0 || side == 1)
// {
//     OpaqueVertices.Add(new VertexPositionNormalTexture((normal - side1 - side2 + position_offset) / 2, normal, Texture[2]));
//     OpaqueVertices.Add(new VertexPositionNormalTexture((normal - side1 + side2 + position_offset) / 2, normal, Texture[3]));
//     OpaqueVertices.Add(new VertexPositionNormalTexture((normal + side1 + side2 + position_offset) / 2, normal, Texture[0]));
//     OpaqueVertices.Add(new VertexPositionNormalTexture((normal + side1 - side2 + position_offset) / 2, normal, Texture[1]));
// }
// else
// {
//     OpaqueVertices.Add(new VertexPositionNormalTexture((normal - side1 - side2 + position_offset) / 2, normal, Texture[0]));
//     OpaqueVertices.Add(new VertexPositionNormalTexture((normal - side1 + side2 + position_offset) / 2, normal, Texture[1]));
//     OpaqueVertices.Add(new VertexPositionNormalTexture((normal + side1 + side2 + position_offset) / 2, normal, Texture[2]));
//     OpaqueVertices.Add(new VertexPositionNormalTexture((normal + side1 - side2 + position_offset) / 2, normal, Texture[3]));
// }