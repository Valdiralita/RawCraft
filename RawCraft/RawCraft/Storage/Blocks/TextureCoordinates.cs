using System;
using System.Collections.Concurrent;
using Microsoft.Xna.Framework;

namespace RawCraft.Storage.Blocks
{
    static class TextureCoordinates
    {
        public static ConcurrentDictionary<Tuple<byte, byte>, Vector2[]> Textures = new ConcurrentDictionary<Tuple<byte, byte>, Vector2[]>();
       //public static ConcurrentDictionary<Tuple<byte, byte>, Vector2[]> TransparentBlocks = new ConcurrentDictionary<Tuple<byte, byte>, Vector2[]>();
       //public static ConcurrentDictionary<int, Vector2[]> NonTransparentBlocks = new ConcurrentDictionary<int, Vector2[]>();
       //public static ConcurrentDictionary<int, Vector2[]> TransparentBlocks = new ConcurrentDictionary<int, Vector2[]>();
       //public static ConcurrentDictionary<int, Vector2[]> NonTransparentBlocks = new ConcurrentDictionary<int, Vector2[]>();
       //public static ConcurrentDictionary<int, Vector2[]> TransparentBlocks = new ConcurrentDictionary<int, Vector2[]>();

        public static void InitializeTextures()
        {
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Stone,            (byte)0),  new Vector2[] { new Vector2(2,  0) / 16, new Vector2(1,  0) / 16, new Vector2(1,  1) / 16, new Vector2(2,   1) / 16 });
                                                                                                                                                                                                         
                                                                                                                                                                                                         
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.GrassBlock,       (byte)0),  new Vector2[] { new Vector2(4,  0) / 16, new Vector2(3,  0) / 16, new Vector2(3,   1) / 16, new Vector2(4,   1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.GrassBlock,       (byte)1),  new Vector2[] { new Vector2(4,  0) / 16, new Vector2(3,  0) / 16, new Vector2(3,   1) / 16, new Vector2(4,   1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.GrassBlock,       (byte)2),  new Vector2[] { new Vector2(4,  0) / 16, new Vector2(3,  0) / 16, new Vector2(3,   1) / 16, new Vector2(4,   1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.GrassBlock,       (byte)3),  new Vector2[] { new Vector2(4,  0) / 16, new Vector2(3,  0) / 16, new Vector2(3,   1) / 16, new Vector2(4,   1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.GrassBlock,       (byte)4),  new Vector2[] { new Vector2(1,  0) / 16, new Vector2(0,  0) / 16, new Vector2(0,   1) / 16, new Vector2(1,   1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.GrassBlock,       (byte)5),  new Vector2[] { new Vector2(3,  0) / 16, new Vector2(2,  0) / 16, new Vector2(2,   1) / 16, new Vector2(3,   1) / 16 });
                                                                                                                                                                                                         
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Dirt,             (byte)0),  new Vector2[] { new Vector2(3,  0) / 16, new Vector2(2,  0) / 16, new Vector2(2,   1) / 16, new Vector2(3,   1) / 16 });
                                                                                                                                                                                                         
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Cobblestone,      (byte)0),  new Vector2[] { new Vector2(1,  1) / 16, new Vector2(0,  1) / 16, new Vector2(0,   2) / 16, new Vector2(1,   2) / 16 });
                                                                                                                                                                                                         
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.WoodenPlanks,     (byte)0),  new Vector2[] { new Vector2(5,  0) / 16, new Vector2(4,  0) / 16, new Vector2(4,   1) / 16, new Vector2(5,   1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.WoodenPlanks,     (byte)1),  new Vector2[] { new Vector2(7, 12) / 16, new Vector2(6, 12) / 16, new Vector2(6,  13) / 16, new Vector2(7,  13) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.WoodenPlanks,     (byte)2),  new Vector2[] { new Vector2(7, 13) / 16, new Vector2(6, 13) / 16, new Vector2(6,  14) / 16, new Vector2(7,  14) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.WoodenPlanks,     (byte)3),  new Vector2[] { new Vector2(8, 12) / 16, new Vector2(7, 12) / 16, new Vector2(7,  13) / 16, new Vector2(8,  13) / 16 });
                                                                                                                                                                                                         
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sapling,          (byte)0),  new Vector2[] { new Vector2(16, 0) / 16, new Vector2(15, 0) / 16, new Vector2(15,  1) / 16, new Vector2(16,  1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sapling,          (byte)1),  new Vector2[] { new Vector2(16, 3) / 16, new Vector2(15, 3) / 16, new Vector2(15,  4) / 16, new Vector2(16,  4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sapling,          (byte)2),  new Vector2[] { new Vector2(16, 4) / 16, new Vector2(15, 4) / 16, new Vector2(15,  5) / 16, new Vector2(16,  5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sapling,          (byte)3),  new Vector2[] { new Vector2(15, 1) / 16, new Vector2(14, 1) / 16, new Vector2(14,  2) / 16, new Vector2(15,  2) / 16 });
                                                                                                                                                                                                          
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Bedrock,          (byte)0),  new Vector2[] { new Vector2(2,  1) / 16, new Vector2(1,  1) / 16, new Vector2(1,   2) / 16, new Vector2(2,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sand,             (byte)0),  new Vector2[] { new Vector2(3,  1) / 16, new Vector2(2,  1) / 16, new Vector2(2,   2) / 16, new Vector2(3,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Gravel,           (byte)0),  new Vector2[] { new Vector2(4,  1) / 16, new Vector2(3,  1) / 16, new Vector2(3,   2) / 16, new Vector2(4,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.GoldOre,          (byte)0),  new Vector2[] { new Vector2(1,  2) / 16, new Vector2(0,  2) / 16, new Vector2(0,   3) / 16, new Vector2(1,   3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.IronOre,          (byte)0),  new Vector2[] { new Vector2(2,  2) / 16, new Vector2(1,  2) / 16, new Vector2(1,   3) / 16, new Vector2(2,   3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.CoalOre,          (byte)0),  new Vector2[] { new Vector2(3,  2) / 16, new Vector2(2,  2) / 16, new Vector2(2,   3) / 16, new Vector2(3,   3) / 16 });
                                                                                                                                                                                                           
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)0),  new Vector2[] { new Vector2(5,  1) / 16, new Vector2(4,  1) / 16, new Vector2(4,   2) / 16, new Vector2(5,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)1),  new Vector2[] { new Vector2(5,  1) / 16, new Vector2(4,  1) / 16, new Vector2(4,   2) / 16, new Vector2(5,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)2),  new Vector2[] { new Vector2(5,  1) / 16, new Vector2(4,  1) / 16, new Vector2(4,   2) / 16, new Vector2(5,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)3),  new Vector2[] { new Vector2(5,  1) / 16, new Vector2(4,  1) / 16, new Vector2(4,   2) / 16, new Vector2(5,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)4),  new Vector2[] { new Vector2(6,  1) / 16, new Vector2(5,  1) / 16, new Vector2(5,   2) / 16, new Vector2(6,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)5),  new Vector2[] { new Vector2(6,  1) / 16, new Vector2(5,  1) / 16, new Vector2(5,   2) / 16, new Vector2(6,   2) / 16 });
                                                                                                                                                                                                          
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)6),  new Vector2[] { new Vector2(5,  7) / 16, new Vector2(4,  7) / 16, new Vector2(4,   8) / 16, new Vector2(5,   8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)7),  new Vector2[] { new Vector2(5,  7) / 16, new Vector2(4,  7) / 16, new Vector2(4,   8) / 16, new Vector2(5,   8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)8),  new Vector2[] { new Vector2(5,  7) / 16, new Vector2(4,  7) / 16, new Vector2(4,   8) / 16, new Vector2(5,   8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)9),  new Vector2[] { new Vector2(5,  7) / 16, new Vector2(4,  7) / 16, new Vector2(4,   8) / 16, new Vector2(5,   8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)10), new Vector2[] { new Vector2(6,  1) / 16, new Vector2(5,  1) / 16, new Vector2(5,   2) / 16, new Vector2(6,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)11), new Vector2[] { new Vector2(6,  1) / 16, new Vector2(5,  1) / 16, new Vector2(5,   2) / 16, new Vector2(6,   2) / 16 });
                                                                                                                                                                                                          
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)12), new Vector2[] { new Vector2(6,  7) / 16, new Vector2(5,  7) / 16, new Vector2(5,   8) / 16, new Vector2(6,   8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)13), new Vector2[] { new Vector2(6,  7) / 16, new Vector2(5,  7) / 16, new Vector2(5,   8) / 16, new Vector2(6,   8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)14), new Vector2[] { new Vector2(6,  7) / 16, new Vector2(5,  7) / 16, new Vector2(5,   8) / 16, new Vector2(6,   8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)15), new Vector2[] { new Vector2(6,  7) / 16, new Vector2(5,  7) / 16, new Vector2(5,   8) / 16, new Vector2(6,   8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)16), new Vector2[] { new Vector2(6,  1) / 16, new Vector2(5,  1) / 16, new Vector2(5,   2) / 16, new Vector2(6,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)17), new Vector2[] { new Vector2(6,  1) / 16, new Vector2(5,  1) / 16, new Vector2(5,   2) / 16, new Vector2(6,   2) / 16 });
                                                                                                                                                                                                         
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)18), new Vector2[] { new Vector2(10, 9) / 16, new Vector2(9,  9) / 16, new Vector2(9,  10) / 16, new Vector2(10, 10) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)19), new Vector2[] { new Vector2(10, 9) / 16, new Vector2(9,  9) / 16, new Vector2(9,  10) / 16, new Vector2(10, 10) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)20), new Vector2[] { new Vector2(10, 9) / 16, new Vector2(9,  9) / 16, new Vector2(9,  10) / 16, new Vector2(10, 10) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)21), new Vector2[] { new Vector2(10, 9) / 16, new Vector2(9,  9) / 16, new Vector2(9,  10) / 16, new Vector2(10, 10) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)22), new Vector2[] { new Vector2(6,  1) / 16, new Vector2(5,  1) / 16, new Vector2(5,   2) / 16, new Vector2(6,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Log,              (byte)23), new Vector2[] { new Vector2(6,  1) / 16, new Vector2(5,  1) / 16, new Vector2(5,   2) / 16, new Vector2(6,   2) / 16 });
                                                                                 
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Leaves,           (byte) 0), new Vector2[] { new Vector2(5,  3) / 16, new Vector2(4,  3) / 16, new Vector2(4,   4) / 16, new Vector2(5,   4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Leaves,           (byte) 1), new Vector2[] { new Vector2(5,  8) / 16, new Vector2(4,  8) / 16, new Vector2(4,   9) / 16, new Vector2(5,   9) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Leaves,           (byte) 2), new Vector2[] { new Vector2(5,  3) / 16, new Vector2(4,  3) / 16, new Vector2(4,   4) / 16, new Vector2(5,   4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Leaves,           (byte) 3), new Vector2[] { new Vector2(5, 12) / 16, new Vector2(4, 12) / 16, new Vector2(4,  13) / 16, new Vector2(5,  13) / 16 });
                                                                                 
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sponge,           (byte) 0), new Vector2[] { new Vector2(1,  3) / 16, new Vector2(0,  3) / 16, new Vector2(0,   4) / 16, new Vector2(1,   4) / 16 });
                                                                                 
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Glass,            (byte) 0), new Vector2[] { new Vector2(2,  3) / 16, new Vector2(1,  3) / 16, new Vector2(1,   4) / 16, new Vector2(2,   4) / 16 });
                                                                                
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.LapisLazuliOre,   (byte) 0), new Vector2[] { new Vector2(1, 10) / 16, new Vector2(0, 10) / 16, new Vector2(0,  11) / 16, new Vector2(1,  11) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.LapisLazuliBlock, (byte) 0), new Vector2[] { new Vector2(1,  9) / 16, new Vector2(0,  9) / 16, new Vector2(0,  10) / 16, new Vector2(1,  10) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Dispenser,        (byte) 0), new Vector2[] { new Vector2(15, 2) / 16, new Vector2(14, 2) / 16, new Vector2(14,  3) / 16, new Vector2(15,  3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Dispenser,        (byte) 1), new Vector2[] { new Vector2(14, 2) / 16, new Vector2(13, 2) / 16, new Vector2(13,  3) / 16, new Vector2(14,  3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Dispenser,        (byte) 2), new Vector2[] { new Vector2(14, 2) / 16, new Vector2(13, 2) / 16, new Vector2(13,  3) / 16, new Vector2(14,  3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Dispenser,        (byte) 3), new Vector2[] { new Vector2(14, 2) / 16, new Vector2(13, 2) / 16, new Vector2(13,  3) / 16, new Vector2(14,  3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Dispenser,        (byte) 4), new Vector2[] { new Vector2(15, 3) / 16, new Vector2(14, 3) / 16, new Vector2(14,  4) / 16, new Vector2(15,  4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Dispenser,        (byte) 5), new Vector2[] { new Vector2(15, 3) / 16, new Vector2(14, 3) / 16, new Vector2(14,  4) / 16, new Vector2(15,  4) / 16 });


            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)0),  new Vector2[] { new Vector2(1, 12) / 16, new Vector2(0, 12) / 16, new Vector2(0, 13) / 16, new Vector2(1,   13) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)1),  new Vector2[] { new Vector2(1, 12) / 16, new Vector2(0, 12) / 16, new Vector2(0, 13) / 16, new Vector2(1,   13) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)2),  new Vector2[] { new Vector2(1, 12) / 16, new Vector2(0, 12) / 16, new Vector2(0, 13) / 16, new Vector2(1,   13) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)3),  new Vector2[] { new Vector2(1, 12) / 16, new Vector2(0, 12) / 16, new Vector2(0, 13) / 16, new Vector2(1,   13) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)4),  new Vector2[] { new Vector2(1, 11) / 16, new Vector2(0, 11) / 16, new Vector2(0, 12) / 16, new Vector2(1,   12) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)5),  new Vector2[] { new Vector2(1, 13) / 16, new Vector2(0, 13) / 16, new Vector2(0, 14) / 16, new Vector2(1,   14) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)6),  new Vector2[] { new Vector2(6, 14) / 16, new Vector2(5, 14) / 16, new Vector2(5, 15) / 16, new Vector2(6,   15) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)7),  new Vector2[] { new Vector2(6, 14) / 16, new Vector2(5, 14) / 16, new Vector2(5, 15) / 16, new Vector2(6,   15) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)8),  new Vector2[] { new Vector2(6, 14) / 16, new Vector2(5, 14) / 16, new Vector2(5, 15) / 16, new Vector2(6,   15) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)9),  new Vector2[] { new Vector2(6, 14) / 16, new Vector2(5, 14) / 16, new Vector2(5, 15) / 16, new Vector2(6,   15) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)10), new Vector2[] { new Vector2(1, 11) / 16, new Vector2(0, 11) / 16, new Vector2(0, 12) / 16, new Vector2(1,   12) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)11), new Vector2[] { new Vector2(1, 13) / 16, new Vector2(0, 13) / 16, new Vector2(0, 14) / 16, new Vector2(1,   14) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)12), new Vector2[] { new Vector2(7, 14) / 16, new Vector2(6, 14) / 16, new Vector2(6, 15) / 16, new Vector2(7,   15) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)13), new Vector2[] { new Vector2(7, 14) / 16, new Vector2(6, 14) / 16, new Vector2(6, 15) / 16, new Vector2(7,   15) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)14), new Vector2[] { new Vector2(7, 14) / 16, new Vector2(6, 14) / 16, new Vector2(6, 15) / 16, new Vector2(7,   15) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)15), new Vector2[] { new Vector2(7, 14) / 16, new Vector2(6, 14) / 16, new Vector2(6, 15) / 16, new Vector2(7,   15) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)16), new Vector2[] { new Vector2(1, 11) / 16, new Vector2(0, 11) / 16, new Vector2(0, 12) / 16, new Vector2(1,   12) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Sandstone,        (byte)17), new Vector2[] { new Vector2(1, 13) / 16, new Vector2(0, 13) / 16, new Vector2(0, 14) / 16, new Vector2(1,   14) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.NoteBlock,        (byte) 0), new Vector2[] { new Vector2(11, 4) / 16, new Vector2(10, 4) / 16, new Vector2(10, 5) / 16, new Vector2(11,   5) / 16 });
                                                                                         
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.PistonSticky,     (byte) 0), new Vector2[] { new Vector2(13, 6) / 16, new Vector2(12, 6) / 16, new Vector2(12, 7) / 16, new Vector2(13,   7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.PistonSticky,     (byte) 1), new Vector2[] { new Vector2(13, 6) / 16, new Vector2(12, 6) / 16, new Vector2(12, 7) / 16, new Vector2(13,   7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.PistonSticky,     (byte) 2), new Vector2[] { new Vector2(13, 6) / 16, new Vector2(12, 6) / 16, new Vector2(12, 7) / 16, new Vector2(13,   7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.PistonSticky,     (byte) 3), new Vector2[] { new Vector2(13, 6) / 16, new Vector2(12, 6) / 16, new Vector2(12, 7) / 16, new Vector2(13,   7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.PistonSticky,     (byte) 4), new Vector2[] { new Vector2(11, 6) / 16, new Vector2(10, 6) / 16, new Vector2(10, 7) / 16, new Vector2(11,   7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.PistonSticky,     (byte) 5), new Vector2[] { new Vector2(14, 6) / 16, new Vector2(13, 6) / 16, new Vector2(13, 7) / 16, new Vector2(14,   7) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Cobweb,           (byte) 0), new Vector2[] { new Vector2(12, 0) / 16, new Vector2(11, 0) / 16, new Vector2(11, 1) / 16, new Vector2(12,   1) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.TallGrass,        (byte) 0), new Vector2[] { new Vector2(8,  3) / 16, new Vector2(7,  3) / 16, new Vector2(7,  4) / 16, new Vector2(8,    4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.TallGrass,        (byte) 1), new Vector2[] { new Vector2(8,  2) / 16, new Vector2(7,  2) / 16, new Vector2(7,  3) / 16, new Vector2(8,    3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.TallGrass,        (byte) 2), new Vector2[] { new Vector2(9,  3) / 16, new Vector2(8,  3) / 16, new Vector2(8,  4) / 16, new Vector2(9,    4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Deadbush,         (byte) 0), new Vector2[] { new Vector2(8,  3) / 16, new Vector2(7,  3) / 16, new Vector2(7,  4) / 16, new Vector2(8,    4) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Piston,           (byte) 0), new Vector2[] { new Vector2(13, 6) / 16, new Vector2(12, 6) / 16, new Vector2(12, 7) / 16, new Vector2(13,   7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Piston,           (byte) 1), new Vector2[] { new Vector2(13, 6) / 16, new Vector2(12, 6) / 16, new Vector2(12, 7) / 16, new Vector2(13,   7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Piston,           (byte) 2), new Vector2[] { new Vector2(13, 6) / 16, new Vector2(12, 6) / 16, new Vector2(12, 7) / 16, new Vector2(13,   7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Piston,           (byte) 3), new Vector2[] { new Vector2(13, 6) / 16, new Vector2(12, 6) / 16, new Vector2(12, 7) / 16, new Vector2(13,   7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Piston,           (byte) 4), new Vector2[] { new Vector2(12, 6) / 16, new Vector2(11, 6) / 16, new Vector2(11, 7) / 16, new Vector2(12,   7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Piston,           (byte) 5), new Vector2[] { new Vector2(14, 6) / 16, new Vector2(13, 6) / 16, new Vector2(13, 7) / 16, new Vector2(14,   7) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte) 0), new Vector2[] { new Vector2(1,  4) / 16, new Vector2(0,  4) / 16, new Vector2(0,  5) / 16, new Vector2(1,    5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte) 1), new Vector2[] { new Vector2(3, 13) / 16, new Vector2(2, 13) / 16, new Vector2(2, 14) / 16, new Vector2(3,   14) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte) 2), new Vector2[] { new Vector2(3, 12) / 16, new Vector2(2, 12) / 16, new Vector2(2, 13) / 16, new Vector2(3,   13) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte) 3), new Vector2[] { new Vector2(3, 11) / 16, new Vector2(2, 11) / 16, new Vector2(2, 12) / 16, new Vector2(3,   12) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte) 4), new Vector2[] { new Vector2(3, 10) / 16, new Vector2(2, 10) / 16, new Vector2(2, 11) / 16, new Vector2(3,   11) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte) 5), new Vector2[] { new Vector2(3,  9) / 16, new Vector2(2,  9) / 16, new Vector2(2, 10) / 16, new Vector2(3,   10) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte) 6), new Vector2[] { new Vector2(3,  8) / 16, new Vector2(2,  8) / 16, new Vector2(2,  9) / 16, new Vector2(3,    9) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte) 7), new Vector2[] { new Vector2(3,  7) / 16, new Vector2(2,  7) / 16, new Vector2(2,  8) / 16, new Vector2(3,    8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte) 8), new Vector2[] { new Vector2(2, 15) / 16, new Vector2(1, 15) / 16, new Vector2(1, 14) / 16, new Vector2(2,   14) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte) 9), new Vector2[] { new Vector2(2, 14) / 16, new Vector2(1, 14) / 16, new Vector2(1, 13) / 16, new Vector2(2,   13) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte)10), new Vector2[] { new Vector2(2, 13) / 16, new Vector2(1, 13) / 16, new Vector2(1, 12) / 16, new Vector2(2,   12) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte)11), new Vector2[] { new Vector2(2, 12) / 16, new Vector2(1, 12) / 16, new Vector2(1, 11) / 16, new Vector2(2,   11) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte)12), new Vector2[] { new Vector2(2, 11) / 16, new Vector2(1, 11) / 16, new Vector2(1, 10) / 16, new Vector2(2,   10) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte)13), new Vector2[] { new Vector2(2, 10) / 16, new Vector2(1, 10) / 16, new Vector2(1,  9) / 16, new Vector2(2,    9) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte)14), new Vector2[] { new Vector2(2,  9) / 16, new Vector2(1,  9) / 16, new Vector2(1,  8) / 16, new Vector2(2,    8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Wool,             (byte)15), new Vector2[] { new Vector2(2,  8) / 16, new Vector2(1,  8) / 16, new Vector2(1,  7) / 16, new Vector2(2,    7) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.YellowFlower,     (byte) 0), new Vector2[] { new Vector2(14, 0) / 16, new Vector2(13, 0) / 16, new Vector2(13, 1) / 16, new Vector2(14,   1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.RedFlower,        (byte) 0), new Vector2[] { new Vector2(13, 0) / 16, new Vector2(12, 0) / 16, new Vector2(12, 1) / 16, new Vector2(13,   1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.BrownMushroom,    (byte) 0), new Vector2[] { new Vector2(14, 1) / 16, new Vector2(13, 1) / 16, new Vector2(13, 2) / 16, new Vector2(14,   2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.RedMushroom,      (byte) 0), new Vector2[] { new Vector2(13, 1) / 16, new Vector2(12, 1) / 16, new Vector2(12, 2) / 16, new Vector2(13,   2) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.GoldBlock,        (byte) 0), new Vector2[] { new Vector2(8,  1) / 16, new Vector2(7,  1) / 16, new Vector2(7,  2) / 16, new Vector2(8,    2) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.IronBlock,        (byte) 0), new Vector2[] { new Vector2(7,  1) / 16, new Vector2(6,  1) / 16, new Vector2(6,  2) / 16, new Vector2(7,    2) / 16 });

            //Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.SlabDouble,        (byte) 0), new Vector2[] { new Vector2(7,  1) / 16, new Vector2(6,  1) / 16, new Vector2(6,  2) / 16, new Vector2(7,    2) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Brick,            (byte) 0), new Vector2[] { new Vector2(8,  0) / 16, new Vector2(7,  0) / 16, new Vector2(7,  1) / 16, new Vector2(8,    1) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.TNT,              (byte) 0), new Vector2[] { new Vector2(9,  0) / 16, new Vector2(8,  0) / 16, new Vector2(8,  1) / 16, new Vector2(9,    1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.TNT,              (byte) 1), new Vector2[] { new Vector2(9,  0) / 16, new Vector2(8,  0) / 16, new Vector2(8,  1) / 16, new Vector2(9,    1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.TNT,              (byte) 2), new Vector2[] { new Vector2(9,  0) / 16, new Vector2(8,  0) / 16, new Vector2(8,  1) / 16, new Vector2(9,    1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.TNT,              (byte) 3), new Vector2[] { new Vector2(9,  0) / 16, new Vector2(8,  0) / 16, new Vector2(8,  1) / 16, new Vector2(9,    1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.TNT,              (byte) 4), new Vector2[] { new Vector2(10, 0) / 16, new Vector2(9,  0) / 16, new Vector2(9,  1) / 16, new Vector2(10,   1) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.TNT,              (byte) 5), new Vector2[] { new Vector2(11, 0) / 16, new Vector2(10, 0) / 16, new Vector2(10, 1) / 16, new Vector2(11,   1) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Bookshelf,        (byte) 0), new Vector2[] { new Vector2(4,  2) / 16, new Vector2(3,  2) / 16, new Vector2(3,  3) / 16, new Vector2(4,    3) / 16 }); //start
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Bookshelf,        (byte) 1), new Vector2[] { new Vector2(4,  2) / 16, new Vector2(3,  2) / 16, new Vector2(3,  3) / 16, new Vector2(4,    3) / 16 }); //start
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Bookshelf,        (byte) 2), new Vector2[] { new Vector2(4,  2) / 16, new Vector2(3,  2) / 16, new Vector2(3,  3) / 16, new Vector2(4,    3) / 16 }); //start
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Bookshelf,        (byte) 3), new Vector2[] { new Vector2(4,  2) / 16, new Vector2(3,  2) / 16, new Vector2(3,  3) / 16, new Vector2(4,    3) / 16 }); //start
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Bookshelf,        (byte) 4), new Vector2[] { new Vector2(5,  0) / 16, new Vector2(4,  0) / 16, new Vector2(4,  1) / 16, new Vector2(5,    1) / 16 }); //start
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Bookshelf,        (byte) 5), new Vector2[] { new Vector2(5,  0) / 16, new Vector2(4,  0) / 16, new Vector2(4,  1) / 16, new Vector2(5,    1) / 16 }); //start
            
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.MossyCobblestone, (byte) 0), new Vector2[] { new Vector2(5,  2) / 16, new Vector2(4,  2) / 16, new Vector2(4,  3) / 16, new Vector2(5,    3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Obsidian,         (byte) 0), new Vector2[] { new Vector2(6,  2) / 16, new Vector2(5,  2) / 16, new Vector2(5,  3) / 16, new Vector2(6,    3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.MobSpawner,       (byte) 0), new Vector2[] { new Vector2(2,  4) / 16, new Vector2(1,  4) / 16, new Vector2(1,  5) / 16, new Vector2(2,    5) / 16 });
           
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.DiamondOre,       (byte) 0), new Vector2[] { new Vector2(3,  3) / 16, new Vector2(2,  3) / 16, new Vector2(2,  4) / 16, new Vector2(3,    4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.DiamondBlock,     (byte) 0), new Vector2[] { new Vector2(9,  1) / 16, new Vector2(8,  1) / 16, new Vector2(8,  2) / 16, new Vector2(9,    2) / 16 });
            
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Workbench,        (byte) 0), new Vector2[] { new Vector2(12, 3) / 16, new Vector2(11, 3) / 16, new Vector2(11, 4) / 16, new Vector2(12,   4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Workbench,        (byte) 1), new Vector2[] { new Vector2(13, 3) / 16, new Vector2(12, 3) / 16, new Vector2(12, 4) / 16, new Vector2(13,   4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Workbench,        (byte) 2), new Vector2[] { new Vector2(12, 3) / 16, new Vector2(11, 3) / 16, new Vector2(11, 4) / 16, new Vector2(12,   4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Workbench,        (byte) 3), new Vector2[] { new Vector2(13, 3) / 16, new Vector2(12, 3) / 16, new Vector2(12, 4) / 16, new Vector2(13,   4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Workbench,        (byte) 4), new Vector2[] { new Vector2(12, 2) / 16, new Vector2(11, 2) / 16, new Vector2(11, 3) / 16, new Vector2(12,   3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Workbench,        (byte) 5), new Vector2[] { new Vector2(5,  0) / 16, new Vector2(4,  0) / 16, new Vector2(4,  1) / 16, new Vector2(5,    1) / 16 }); //check if correct

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 0), new Vector2[] { new Vector2(13, 2) / 16, new Vector2(12, 2) / 16, new Vector2(12, 3) / 16, new Vector2(13,   3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 1), new Vector2[] { new Vector2(14, 2) / 16, new Vector2(13, 2) / 16, new Vector2(13, 3) / 16, new Vector2(14,   3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 2), new Vector2[] { new Vector2(14, 2) / 16, new Vector2(13, 2) / 16, new Vector2(13, 3) / 16, new Vector2(14,   3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 3), new Vector2[] { new Vector2(14, 2) / 16, new Vector2(13, 2) / 16, new Vector2(13, 3) / 16, new Vector2(14,   3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 4), new Vector2[] { new Vector2(15, 3) / 16, new Vector2(14, 3) / 16, new Vector2(14, 4) / 16, new Vector2(15,   4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 5), new Vector2[] { new Vector2(15, 3) / 16, new Vector2(14, 3) / 16, new Vector2(14, 4) / 16, new Vector2(15,   4) / 16 });
                                                                                                                                                                                                          
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 0), new Vector2[] { new Vector2(13, 2) / 16, new Vector2(12, 2) / 16, new Vector2(12, 3) / 16, new Vector2(13,   3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 1), new Vector2[] { new Vector2(14, 2) / 16, new Vector2(13, 2) / 16, new Vector2(13, 3) / 16, new Vector2(14,   3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 2), new Vector2[] { new Vector2(14, 2) / 16, new Vector2(13, 2) / 16, new Vector2(13, 3) / 16, new Vector2(14,   3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 3), new Vector2[] { new Vector2(14, 2) / 16, new Vector2(13, 2) / 16, new Vector2(13, 3) / 16, new Vector2(14,   3) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 4), new Vector2[] { new Vector2(15, 3) / 16, new Vector2(14, 3) / 16, new Vector2(14, 4) / 16, new Vector2(15,   4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Furnace,          (byte) 5), new Vector2[] { new Vector2(15, 3) / 16, new Vector2(14, 3) / 16, new Vector2(14, 4) / 16, new Vector2(15,   4) / 16 });
                                                                                                                                                                                                          
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.RedstoneOre,      (byte) 0), new Vector2[] { new Vector2(4,  3) / 16, new Vector2(3,  3) / 16, new Vector2(3,  4) / 16, new Vector2(4,    4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.RedstoneOreGlow,  (byte) 0), new Vector2[] { new Vector2(4,  3) / 16, new Vector2(3,  3) / 16, new Vector2(3,  4) / 16, new Vector2(4,    4) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Ice,              (byte) 0), new Vector2[] { new Vector2(4,  4) / 16, new Vector2(3,  4) / 16, new Vector2(3,  5) / 16, new Vector2(4,    5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.SnowBlock,        (byte) 0), new Vector2[] { new Vector2(3,  4) / 16, new Vector2(2,  4) / 16, new Vector2(2,  5) / 16, new Vector2(3,    5) / 16 });
            
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Clay,             (byte) 0), new Vector2[] { new Vector2(9,  4) / 16, new Vector2(8,  4) / 16, new Vector2(8,  5) / 16, new Vector2(9,    5) / 16 });
                                                                               
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Jukebox,          (byte) 0), new Vector2[] { new Vector2(11, 4) / 16, new Vector2(10, 4) / 16, new Vector2(10, 5) / 16, new Vector2(11,   5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Jukebox,          (byte) 1), new Vector2[] { new Vector2(11, 4) / 16, new Vector2(10, 4) / 16, new Vector2(10, 5) / 16, new Vector2(11,   5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Jukebox,          (byte) 2), new Vector2[] { new Vector2(11, 4) / 16, new Vector2(10, 4) / 16, new Vector2(10, 5) / 16, new Vector2(11,   5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Jukebox,          (byte) 3), new Vector2[] { new Vector2(11, 4) / 16, new Vector2(10, 4) / 16, new Vector2(10, 5) / 16, new Vector2(11,   5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Jukebox,          (byte) 4), new Vector2[] { new Vector2(12, 4) / 16, new Vector2(11, 4) / 16, new Vector2(11, 5) / 16, new Vector2(12,   5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Jukebox,          (byte) 5), new Vector2[] { new Vector2(11, 4) / 16, new Vector2(10, 4) / 16, new Vector2(10, 5) / 16, new Vector2(11,   5) / 16 });
             
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Pumpkin,          (byte) 0), new Vector2[] { new Vector2(8,  7) / 16, new Vector2(7,  7) / 16, new Vector2(7,  8) / 16, new Vector2(8,    8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Pumpkin,          (byte) 1), new Vector2[] { new Vector2(7,  7) / 16, new Vector2(6,  7) / 16, new Vector2(6,  8) / 16, new Vector2(7,    8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Pumpkin,          (byte) 2), new Vector2[] { new Vector2(7,  7) / 16, new Vector2(6,  7) / 16, new Vector2(6,  8) / 16, new Vector2(7,    8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Pumpkin,          (byte) 3), new Vector2[] { new Vector2(7,  7) / 16, new Vector2(6,  7) / 16, new Vector2(6,  8) / 16, new Vector2(7,    8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Pumpkin,          (byte) 4), new Vector2[] { new Vector2(7,  6) / 16, new Vector2(6,  6) / 16, new Vector2(6,  7) / 16, new Vector2(7,    7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Pumpkin,          (byte) 5), new Vector2[] { new Vector2(7,  6) / 16, new Vector2(6,  6) / 16, new Vector2(6,  7) / 16, new Vector2(7,    7) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Netherrack,       (byte) 0), new Vector2[] { new Vector2(8,  6) / 16, new Vector2(7,  6) / 16, new Vector2(7,  7) / 16, new Vector2(8,    7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Soulsand,         (byte) 0), new Vector2[] { new Vector2(9,  6) / 16, new Vector2(8,  6) / 16, new Vector2(8,  7) / 16, new Vector2(9,    7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Glowstone,        (byte) 0), new Vector2[] { new Vector2(10, 6) / 16, new Vector2(9,  6) / 16, new Vector2(9,  7) / 16, new Vector2(10,   7) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.JackOLantern,     (byte) 0), new Vector2[] { new Vector2(9,  7) / 16, new Vector2(8,  7) / 16, new Vector2(8,  8) / 16, new Vector2(9,    8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.JackOLantern,     (byte) 1), new Vector2[] { new Vector2(7,  7) / 16, new Vector2(6,  7) / 16, new Vector2(6,  8) / 16, new Vector2(7,    8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.JackOLantern,     (byte) 2), new Vector2[] { new Vector2(7,  7) / 16, new Vector2(6,  7) / 16, new Vector2(6,  8) / 16, new Vector2(7,    8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.JackOLantern,     (byte) 3), new Vector2[] { new Vector2(7,  7) / 16, new Vector2(6,  7) / 16, new Vector2(6,  8) / 16, new Vector2(7,    8) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.JackOLantern,     (byte) 4), new Vector2[] { new Vector2(7,  6) / 16, new Vector2(6,  6) / 16, new Vector2(6,  7) / 16, new Vector2(7,    7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.JackOLantern,     (byte) 5), new Vector2[] { new Vector2(7,  6) / 16, new Vector2(6,  6) / 16, new Vector2(6,  7) / 16, new Vector2(7,    7) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.StoneBricks,      (byte) 0), new Vector2[] { new Vector2(7,  3) / 16, new Vector2(6,  3) / 16, new Vector2(6,  4) / 16, new Vector2(7,    4) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.StoneBricks,      (byte) 1), new Vector2[] { new Vector2(6,  6) / 16, new Vector2(5,  6) / 16, new Vector2(5,  7) / 16, new Vector2(6,    7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.StoneBricks,      (byte) 2), new Vector2[] { new Vector2(5,  6) / 16, new Vector2(4,  6) / 16, new Vector2(4,  7) / 16, new Vector2(5,    7) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.StoneBricks,      (byte) 3), new Vector2[] { new Vector2(6, 13) / 16, new Vector2(5, 13) / 16, new Vector2(5, 14) / 16, new Vector2(6,   14) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Melon,            (byte) 0), new Vector2[] { new Vector2(9,  8) / 16, new Vector2(8,  8) / 16, new Vector2(8,  9) / 16, new Vector2(9,    9) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Melon,            (byte) 1), new Vector2[] { new Vector2(9,  8) / 16, new Vector2(8,  8) / 16, new Vector2(8,  9) / 16, new Vector2(9,    9) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Melon,            (byte) 2), new Vector2[] { new Vector2(9,  8) / 16, new Vector2(8,  8) / 16, new Vector2(8,  9) / 16, new Vector2(9,    9) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Melon,            (byte) 3), new Vector2[] { new Vector2(9,  8) / 16, new Vector2(8,  8) / 16, new Vector2(8,  9) / 16, new Vector2(9,    9) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Melon,            (byte) 4), new Vector2[] { new Vector2(10, 8) / 16, new Vector2(9,  8) / 16, new Vector2(9,  9) / 16, new Vector2(10,   9) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Melon,            (byte) 5), new Vector2[] { new Vector2(10, 8) / 16, new Vector2(9,  8) / 16, new Vector2(9,  9) / 16, new Vector2(10,   9) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Mycelium,         (byte) 0), new Vector2[] { new Vector2(14, 4) / 16, new Vector2(13, 4) / 16, new Vector2(13, 5) / 16, new Vector2(14,   5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Mycelium,         (byte) 1), new Vector2[] { new Vector2(14, 4) / 16, new Vector2(13, 4) / 16, new Vector2(13, 5) / 16, new Vector2(14,   5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Mycelium,         (byte) 2), new Vector2[] { new Vector2(14, 4) / 16, new Vector2(13, 4) / 16, new Vector2(13, 5) / 16, new Vector2(14,   5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Mycelium,         (byte) 3), new Vector2[] { new Vector2(14, 4) / 16, new Vector2(13, 4) / 16, new Vector2(13, 5) / 16, new Vector2(14,   5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Mycelium,         (byte) 4), new Vector2[] { new Vector2(15, 4) / 16, new Vector2(14, 4) / 16, new Vector2(14, 5) / 16, new Vector2(15,   5) / 16 });
            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Mycelium,         (byte) 5), new Vector2[] { new Vector2(3,  0) / 16, new Vector2(2,  0) / 16, new Vector2(2,  1) / 16, new Vector2(3,    1) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.NetherBrick,      (byte) 0), new Vector2[] { new Vector2(1, 14) / 16, new Vector2(0, 14) / 16, new Vector2(0, 15) / 16, new Vector2(1,   15) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.EndStone,         (byte) 0), new Vector2[] { new Vector2(16,10) / 16, new Vector2(15,10) / 16, new Vector2(15,11) / 16, new Vector2(16,  11) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.EmeraldOre,       (byte) 0), new Vector2[] { new Vector2(16,10) / 16, new Vector2(15,10) / 16, new Vector2(15,11) / 16, new Vector2(16,  11) / 16 });

            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.EmeraldBlock,     (byte) 0), new Vector2[] { new Vector2(12,10) / 16, new Vector2(11,10) / 16, new Vector2(11,11) / 16, new Vector2(12,  11) / 16 });








            Textures.TryAdd(Tuple.Create((byte)BlockEnum.Blocks.Water,            (byte) 0), new Vector2[] { new Vector2(14,12) / 16, new Vector2(13,12) / 16, new Vector2(13,13) / 16, new Vector2(14,  13) / 16 });
        }
    }
}
