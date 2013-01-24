using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RawCraft.Storage.Blocks;
using RawCraft.Storage.Map;

namespace RawCraft.Renderer
{
    public class VertexIndexGenerator
    {
        List<VertexPositionNormalTexture> _opaqueVertices;
        List<int> _opaqueIndices;
        List<VertexPositionNormalTexture> _transparentVertices;
        List<int> _transparentIndices;

        int _x, _y, _z;
        byte _id, _meta; 
        Chunk _chunk;

        public VertexIndexGenerator()
        {
            _opaqueVertices = new List<VertexPositionNormalTexture>();
            _opaqueIndices = new List<int>();
            _transparentVertices = new List<VertexPositionNormalTexture>();
            _transparentIndices = new List<int>();
        }

        static readonly Vector3[] Normals =
        {
            new Vector3(0, 0, 1),  //5
            new Vector3(0, 0, -1), //2
            new Vector3(1, 0, 0),  //3
            new Vector3(-1, 0, 0), //4
            new Vector3(0, 1, 0),  //6
            new Vector3(0, -1, 0)  //1
        };

        public Mesh[] Generate(Chunk c, GraphicsDevice gd)
        {
            _x = 0;
            _y = 0;
            _z = 0;

            _chunk = c;

            for (; ; _x++)
            {
                if (_x > 15)
                {
                    _z++;
                    _x = 0;
                    if (_z > 15)
                    {
                        _y++;
                        _z = 0;
                        if (_y > 255)
                        {
                            break;
                        }
                    }
                }

                _id = c.BlockType[_x, _y, _z];
                _meta = c.BlockMetadata[_x, _y, _z];

                if (!Blocks.blocks[_id].NotABlock && !Blocks.blocks[_id].IsTransparent)
                {
                    if (!Blocks.blocks[_id].HasMetadata)
                    {
                        if (Blocks.blocks[_id].IsMultitex)
                        {
                            if (IsTransparent(0))
                                CreateMultiTexBlockSide(0, 0);
                            if (IsTransparent(1))
                                CreateMultiTexBlockSide(1, 1);
                            if (IsTransparent(2))
                                CreateMultiTexBlockSide(2, 2);
                            if (IsTransparent(3))
                                CreateMultiTexBlockSide(3, 3);
                            if (IsTransparent(4))
                                CreateMultiTexBlockSide(4, 4);
                            if (IsTransparent(5))
                                CreateMultiTexBlockSide(5, 5);
                        }
                        else
                        {
                            if (IsTransparent(0))
                                CreateBlockSide(0);
                            if (IsTransparent(1))
                                CreateBlockSide(1);
                            if (IsTransparent(2))
                                CreateBlockSide(2);
                            if (IsTransparent(3))
                                CreateBlockSide(3);
                            if (IsTransparent(4))
                                CreateBlockSide(4);
                            if (IsTransparent(5))
                                CreateBlockSide(5);
                        }
                    }
                    else
                    {
                        if (Blocks.blocks[_id].IsMultitex)
                        {
                            if (IsTransparent(0))
                                CreateMultiTexBlockSide(0, (byte)(0 + _meta * 6));
                            if (IsTransparent(1))
                                CreateMultiTexBlockSide(1, (byte)(1 + _meta * 6));
                            if (IsTransparent(2))
                                CreateMultiTexBlockSide(2, (byte)(2 + _meta * 6));
                            if (IsTransparent(3))
                                CreateMultiTexBlockSide(3, (byte)(3 + _meta * 6));
                            if (IsTransparent(4))
                                CreateMultiTexBlockSide(4, (byte)(4 + _meta * 6));
                            if (IsTransparent(5))
                                CreateMultiTexBlockSide(5, (byte)(5 + _meta * 6));
                        }
                        else
                        {
                            if (IsTransparent(0))
                                CreateBlockSide(0);
                            if (IsTransparent(1))
                                CreateBlockSide(1);
                            if (IsTransparent(2))
                                CreateBlockSide(2);
                            if (IsTransparent(3))
                                CreateBlockSide(3);
                            if (IsTransparent(4))
                                CreateBlockSide(4);
                            if (IsTransparent(5))
                                CreateBlockSide(5);
                        }
                    }
                }
                else if (Blocks.blocks[_id].NotABlock)
                {
                    if (Blocks.blocks[_id].IsXSprite)
                    {
                        CreateXSprite();
                    }
                    else if (_id == 9)//quick hack for water
                    {
                        if (c.BlockType[_x, _y + 1, _z] != 9)
                            CreateWater(4);
                    }
                    else if (_id == 79) //ice 
                    {
                        if (!SameBlock(0))
                            TransparentQuad(0);
                        if (!SameBlock(1))
                            TransparentQuad(1);
                        if (!SameBlock(2))
                            TransparentQuad(2);
                        if (!SameBlock(3))
                            TransparentQuad(3);
                        if (!SameBlock(4))
                            TransparentQuad(4);
                        if (!SameBlock(5))
                            TransparentQuad(5);
                    }
                }
                else if (Blocks.blocks[_id].IsTransparent)
                {
                    if (_id == 18) // leaves
                    {
                        CreateBlockSide(0);
                        CreateBlockSide(1);
                        CreateBlockSide(2);
                        CreateBlockSide(3);
                        CreateBlockSide(4);
                        CreateBlockSide(5);
                    }
                    else if (_id == 20)
                    {
                        if (!SameBlock(0))
                            CreateBlockSide(0);
                        if (!SameBlock(1))
                            CreateBlockSide(1);
                        if (!SameBlock(2))
                            CreateBlockSide(2);
                        if (!SameBlock(3))
                            CreateBlockSide(3);
                        if (!SameBlock(4))
                            CreateBlockSide(4);
                        if (!SameBlock(5))
                            CreateBlockSide(5);
                    }
                }
            }

            Mesh[] meshes = new Mesh[2];

            if (_opaqueIndices.Count > 0)
                meshes[0] = new Mesh(gd, _opaqueVertices.ToArray(), _opaqueIndices.ToArray());
            if (_transparentIndices.Count > 0)
                meshes[1] = new Mesh(gd, _transparentVertices.ToArray(), _transparentIndices.ToArray());

            _opaqueVertices = new List<VertexPositionNormalTexture>();
            _opaqueIndices = new List<int>();
            _transparentVertices = new List<VertexPositionNormalTexture>();
            _transparentIndices = new List<int>();

            return meshes;
        }


        private void CreateBlockSide(byte side)
        {
            Vector2[] tex;

            if (TextureCoordinates.Textures.TryGetValue(Tuple.Create(_id, _meta), out tex))
            {
                CreateQuad(side, tex);
            }
        }

        private void CreateMultiTexBlockSide(byte side, byte texpos)
        {
            Vector2[] tex;

            if (TextureCoordinates.Textures.TryGetValue(Tuple.Create(_id, texpos), out tex))
            {
                CreateQuad(side, tex);
            }
        }

        private void CreateQuad(byte side, Vector2[] tex)
        {
            Vector3 positionOffset = new Vector3(16 * _chunk.ChunkX + _x + 0.5f, _y + 0.5f, _z + 0.5f + 16 * _chunk.ChunkZ);

            _opaqueIndices.Add(_opaqueVertices.Count + 1);
            _opaqueIndices.Add(_opaqueVertices.Count + 0);
            _opaqueIndices.Add(_opaqueVertices.Count + 3);

            _opaqueIndices.Add(_opaqueVertices.Count + 1);
            _opaqueIndices.Add(_opaqueVertices.Count + 3);
            _opaqueIndices.Add(_opaqueVertices.Count + 2);

            int i = 0;

            foreach (Vector3 vec in VertexPositions.Block[side])
            {
                _opaqueVertices.Add(new VertexPositionNormalTexture(vec + positionOffset, Normals[side], tex[i]));
                if (++i > 3)
                    i = 0;
            }
        }

        private void CreateXSprite()
        {
            Vector2[] tex;
            if (TextureCoordinates.Textures.TryGetValue(Tuple.Create(_id, _meta), out tex))
            {
                Vector3 positionOffset = new Vector3(16 * _chunk.ChunkX + _x + 0.5f, _y + 0.5f, _z + 0.5f + 16 * _chunk.ChunkZ);

                for (int i = 0; i < 4; i++)
                {
                    _opaqueIndices.Add(_opaqueVertices.Count + 0 + 4 * i);
                    _opaqueIndices.Add(_opaqueVertices.Count + 1 + 4 * i);
                    _opaqueIndices.Add(_opaqueVertices.Count + 2 + 4 * i);
                    _opaqueIndices.Add(_opaqueVertices.Count + 0 + 4 * i);
                    _opaqueIndices.Add(_opaqueVertices.Count + 2 + 4 * i);
                    _opaqueIndices.Add(_opaqueVertices.Count + 3 + 4 * i);
                }

                int j = 0;

                foreach (Vector3 vec in VertexPositions.XSprite)
                {
                    _opaqueVertices.Add(new VertexPositionNormalTexture(vec + positionOffset, Vector3.Zero, tex[j]));
                    if (++j > 3)
                        j = 0;
                }
            }
        }

        private void TransparentQuad(byte side) //todo: update
        {
            Vector2[] tex;
            if (TextureCoordinates.Textures.TryGetValue(Tuple.Create(_id, (byte)0), out tex))
            {
                Vector3 normal = Normals[side];

                Vector3 side1 = new Vector3(normal.Y, normal.Z, normal.X);
                Vector3 side2 = Vector3.Cross(normal, side1);

                Vector3 positionOffset = new Vector3(16 * _chunk.ChunkX + _x + 0.5f, _y + 0.5f, _z + 0.5f + 16 * _chunk.ChunkZ) * 2;

                _transparentIndices.Add(_transparentVertices.Count + 0);
                _transparentIndices.Add(_transparentVertices.Count + 1);
                _transparentIndices.Add(_transparentVertices.Count + 2);

                _transparentIndices.Add(_transparentVertices.Count + 0);
                _transparentIndices.Add(_transparentVertices.Count + 2);
                _transparentIndices.Add(_transparentVertices.Count + 3);

                _transparentVertices.Add(new VertexPositionNormalTexture((normal - side1 - side2 + positionOffset) / 2, normal, tex[0]));
                _transparentVertices.Add(new VertexPositionNormalTexture((normal - side1 + side2 + positionOffset) / 2, normal, tex[1]));
                _transparentVertices.Add(new VertexPositionNormalTexture((normal + side1 + side2 + positionOffset) / 2, normal, tex[2]));
                _transparentVertices.Add(new VertexPositionNormalTexture((normal + side1 - side2 + positionOffset) / 2, normal, tex[3]));
            }
        }

        private void CreateWater(byte side) //todo: update
        {
            Vector2[] tex;
            if (TextureCoordinates.Textures.TryGetValue(Tuple.Create(_id, (byte)0), out tex))
            {
                Vector3 normal = Normals[side];

                Vector3 side1 = new Vector3(normal.Y, normal.Z, normal.X);
                Vector3 side2 = Vector3.Cross(normal, side1);

                Vector3 positionOffset = new Vector3(16 * _chunk.ChunkX + _x + 0.5f, _y + 0.4f, _z + 0.5f + 16 * _chunk.ChunkZ) * 2;

                _transparentIndices.Add(_transparentVertices.Count + 0);
                _transparentIndices.Add(_transparentVertices.Count + 1);
                _transparentIndices.Add(_transparentVertices.Count + 2);

                _transparentIndices.Add(_transparentVertices.Count + 0);
                _transparentIndices.Add(_transparentVertices.Count + 2);
                _transparentIndices.Add(_transparentVertices.Count + 3);

                _transparentVertices.Add(new VertexPositionNormalTexture((normal - side1 - side2 + positionOffset) / 2, normal, tex[0]));
                _transparentVertices.Add(new VertexPositionNormalTexture((normal - side1 + side2 + positionOffset) / 2, normal, tex[1]));
                _transparentVertices.Add(new VertexPositionNormalTexture((normal + side1 + side2 + positionOffset) / 2, normal, tex[2]));
                _transparentVertices.Add(new VertexPositionNormalTexture((normal + side1 - side2 + positionOffset) / 2, normal, tex[3]));
            }
        }

        private bool IsTransparent(byte side)
        {
            Chunk adjacentChunk;

            switch (side)
            {
                case 0: // Z+
                    {
                        if (_z == 15)
                        {
                            if (MapChunks.Map.TryGetValue(new Vector2(_chunk.ChunkX, _chunk.ChunkZ + 1), out adjacentChunk))
                                if (Blocks.blocks[adjacentChunk.BlockType[_x, _y, 0]].IsTransparent || Blocks.blocks[adjacentChunk.BlockType[_x, _y, 0]].NotABlock)
                                    return true;
                            return false;
                        }
                        return Blocks.blocks[_chunk.BlockType[_x, _y, _z + 1]].IsTransparent || Blocks.blocks[_chunk.BlockType[_x, _y, _z + 1]].NotABlock;
                    }
                case 1: // Z-
                    {
                        if (_z == 0)
                        {
                            if (MapChunks.Map.TryGetValue(new Vector2(_chunk.ChunkX, _chunk.ChunkZ - 1), out adjacentChunk))
                                if (Blocks.blocks[adjacentChunk.BlockType[_x, _y, 15]].IsTransparent || Blocks.blocks[adjacentChunk.BlockType[_x, _y, 15]].NotABlock)
                                    return true;
                            return false;
                        }
                        return Blocks.blocks[_chunk.BlockType[_x, _y, _z - 1]].IsTransparent || Blocks.blocks[_chunk.BlockType[_x, _y, _z - 1]].NotABlock;
                    }
                case 2: // X+
                    {
                        if (_x == 15)
                        {
                            if (MapChunks.Map.TryGetValue(new Vector2(_chunk.ChunkX + 1, _chunk.ChunkZ), out adjacentChunk))
                                if (Blocks.blocks[adjacentChunk.BlockType[0, _y, _z]].IsTransparent || Blocks.blocks[adjacentChunk.BlockType[0, _y, _z]].NotABlock)
                                    return true;
                            return false;
                        }
                        return Blocks.blocks[_chunk.BlockType[_x + 1, _y, _z]].IsTransparent || Blocks.blocks[_chunk.BlockType[_x + 1, _y, _z]].NotABlock;
                    }
                case 3: // X-
                    {
                        if (_x == 0)
                        {
                            if (MapChunks.Map.TryGetValue(new Vector2(_chunk.ChunkX - 1, _chunk.ChunkZ), out adjacentChunk))
                                if (Blocks.blocks[adjacentChunk.BlockType[15, _y, _z]].IsTransparent || Blocks.blocks[adjacentChunk.BlockType[15, _y, _z]].NotABlock)
                                    return true;
                            return false;
                        }
                        return Blocks.blocks[_chunk.BlockType[_x - 1, _y, _z]].IsTransparent || Blocks.blocks[_chunk.BlockType[_x - 1, _y, _z]].NotABlock;
                    }
                case 4:
                    {
                        return _y == 255 ||
                               (Blocks.blocks[_chunk.BlockType[_x, _y + 1, _z]].IsTransparent ||
                                Blocks.blocks[_chunk.BlockType[_x, _y + 1, _z]].NotABlock);
                    }
                case 5:
                    {
                        return _y != 0 &&
                               (Blocks.blocks[_chunk.BlockType[_x, _y - 1, _z]].NotABlock ||
                                Blocks.blocks[_chunk.BlockType[_x, _y - 1, _z]].IsTransparent);
                    }
                default:
                    return false;
            }
        }

        private bool SameBlock(byte side)
        {
            Chunk adjacentChunk;

            switch (side)
            {
                case 0: // Z+
                    {
                        if (_z == 15)
                        {
                            if (MapChunks.Map.TryGetValue(new Vector2(_chunk.ChunkX, _chunk.ChunkZ + 1), out adjacentChunk))
                                if (adjacentChunk.BlockType[_x, _y, 0] == _id)
                                    return true;
                            return false;
                        }
                        return _chunk.BlockType[_x, _y, _z + 1] == _id;
                    }
                case 1: // Z-
                    {
                        if (_z == 0)
                        {
                            if (MapChunks.Map.TryGetValue(new Vector2(_chunk.ChunkX, _chunk.ChunkZ - 1), out adjacentChunk))
                                if (adjacentChunk.BlockType[_x, _y, 15] == _id)
                                    return true;
                            return false;
                        }
                        return _chunk.BlockType[_x, _y, _z - 1] == _id;
                    }
                case 2: // X+
                    {
                        if (_x == 15)
                        {
                            if (MapChunks.Map.TryGetValue(new Vector2(_chunk.ChunkX + 1, _chunk.ChunkZ), out adjacentChunk))
                                if (adjacentChunk.BlockType[0, _y, _z] == _id)
                                    return true;
                            return false;
                        }
                        return _chunk.BlockType[_x + 1, _y, _z] == _id;
                    }
                case 3: // X-
                    {
                        if (_x == 0)
                        {
                            if (MapChunks.Map.TryGetValue(new Vector2(_chunk.ChunkX - 1, _chunk.ChunkZ), out adjacentChunk))
                                if (adjacentChunk.BlockType[15, _y, _z] == _id)
                                    return true;
                            return false;
                        }
                        return _chunk.BlockType[_x - 1, _y, _z] == _id;
                    }
                case 4:
                    {
                        return _y == 255 || _chunk.BlockType[_x, _y + 1, _z] == _id;
                    }
                case 5:
                    {
                        return _y != 0 && _chunk.BlockType[_x, _y - 1, _z] == _id;
                    }
                default:
                    return false;
            }
        }
    }
}