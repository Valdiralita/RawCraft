namespace RawCraft.Storage.Blocks
{
    static class Blocks
    {
        public static Block[] blocks;

        public static void InitialzizeBlocks()
        {
            blocks = new Block[158];
            for (int i = 0; i < blocks.Length; i++)
                blocks[i] = new Block();

            blocks[0].IsTransparent = true;


            blocks[2].IsMultitex = true;


            blocks[5].HasMetadata = true;

            blocks[6].NotABlock = true;
            blocks[6].IsXSprite = true;

            blocks[8].NotABlock = true;

            blocks[9].NotABlock = true;

            blocks[10].NotABlock = true;

            blocks[11].NotABlock = true;

            blocks[17].IsMultitex = true;
            blocks[17].HasMetadata = true;

            blocks[18].IsTransparent = true;
            blocks[18].HasMetadata = true;

            blocks[20].IsTransparent = true;

            blocks[23].IsMultitex = true;

            blocks[24].IsMultitex = true;
            blocks[24].HasMetadata = true;

            blocks[25].HasMetadata = true;

            blocks[26].NotABlock = true;

            blocks[27].NotABlock = true;

            blocks[28].NotABlock = true;

            // blocks[29].HasMetadata = true; <-- enable this after fixing the vertexindexgenerator
            blocks[29].IsMultitex = true;

            blocks[30].NotABlock = true;

            blocks[31].NotABlock = true;
            blocks[31].IsXSprite = true;

            blocks[32].NotABlock = true;
            blocks[32].IsXSprite = true;

            blocks[33].IsMultitex = true;
            // blocks[33].HasMetadata = true; <-- enable this after fixing the vertexindexgenerator

            blocks[34].NotABlock = true;

            blocks[35].HasMetadata = true;

            blocks[36].NotABlock = true;

            blocks[37].NotABlock = true;
            blocks[37].IsXSprite = true;

            blocks[38].NotABlock = true;
            blocks[38].IsXSprite = true;

            blocks[39].NotABlock = true;
            blocks[39].IsXSprite = true;

            blocks[40].NotABlock = true;
            blocks[40].IsXSprite = true;


            blocks[43].IsMultitex = true;
            blocks[43].HasMetadata = true;

            blocks[44].IsTransparent = true;
            blocks[44].HasMetadata = true;

            blocks[46].IsMultitex = true;

            blocks[47].IsMultitex = true;


            blocks[50].NotABlock = true;

            blocks[51].NotABlock = true;

            blocks[52].IsTransparent = true;

            blocks[53].IsTransparent = true;

            blocks[54].NotABlock = true;

            blocks[55].NotABlock = true;

            blocks[58].IsMultitex = true;

            blocks[59].NotABlock = true;
            blocks[59].IsXSprite = true;

            blocks[60].IsTransparent = true;
            blocks[60].IsMultitex = true;

            blocks[61].IsMultitex = true;

            blocks[62].IsMultitex = true;

            blocks[63].NotABlock = true;

            blocks[64].NotABlock = true;

            blocks[65].NotABlock = true;

            blocks[66].NotABlock = true;

            blocks[67].IsTransparent = true;
            blocks[67].HasMetadata = true;

            blocks[68].NotABlock = true;

            blocks[69].NotABlock = true;

            blocks[70].NotABlock = true;

            blocks[71].NotABlock = true;

            blocks[72].NotABlock = true;


            blocks[75].NotABlock = true;

            blocks[76].NotABlock = true;

            blocks[77].NotABlock = true;

            blocks[78].IsTransparent = true;

            blocks[79].NotABlock = true;


            blocks[81].NotABlock = true;

            blocks[83].NotABlock = true;
            blocks[83].IsXSprite = true;

            blocks[84].IsMultitex = true;

            blocks[85].NotABlock = true;

            blocks[86].IsMultitex = true;


            blocks[90].NotABlock = true;

            blocks[91].IsMultitex = true;

            blocks[92].NotABlock = true;

            blocks[93].NotABlock = true;

            blocks[94].NotABlock = true;

            blocks[95].NotABlock = true;

            blocks[96].NotABlock = true;

            blocks[99].IsMultitex = true;

            blocks[100].IsMultitex = true;

            blocks[101].NotABlock = true;

            blocks[102].NotABlock = true;

            blocks[103].IsMultitex = true;

            blocks[104].NotABlock = true;
            blocks[104].IsXSprite = true;

            blocks[105].NotABlock = true;
            blocks[105].IsXSprite = true;

            blocks[106].NotABlock = true;

            blocks[107].NotABlock = true;

            blocks[108].IsTransparent = true;

            blocks[109].IsTransparent = true;

            blocks[110].IsMultitex = true;

            blocks[111].NotABlock = true;


            blocks[113].NotABlock = true;

            blocks[114].IsTransparent = true;

            blocks[115].NotABlock = true;
            blocks[115].IsXSprite = true;

            blocks[116].NotABlock = true;

            blocks[117].NotABlock = true;
            blocks[117].IsXSprite = true;

            blocks[118].NotABlock = true;

            blocks[119].NotABlock = true;

            blocks[120].NotABlock = true;


            blocks[122].NotABlock = true;


            blocks[126].IsTransparent = true;

            blocks[127].NotABlock = true;

            blocks[128].IsTransparent = true;


            blocks[130].NotABlock = true;

            blocks[131].NotABlock = true;

            blocks[132].NotABlock = true;


            blocks[134].IsTransparent = true;

            blocks[135].IsTransparent = true;

            blocks[136].IsTransparent = true;


            blocks[138].IsTransparent = true;

            blocks[139].NotABlock = true;

            blocks[140].NotABlock = true;

            blocks[141].NotABlock = true;

            blocks[142].NotABlock = true;

            blocks[143].NotABlock = true;

            blocks[144].NotABlock = true;

            blocks[145].NotABlock = true;

            blocks[146].NotABlock = true;

            blocks[147].NotABlock = true;

            blocks[148].NotABlock = true;

            blocks[149].NotABlock = true;

            blocks[150].NotABlock = true;

            blocks[151].NotABlock = true;


            blocks[154].NotABlock = true;


            blocks[156].NotABlock = true;

            blocks[157].NotABlock = true;
        }
    }
}
