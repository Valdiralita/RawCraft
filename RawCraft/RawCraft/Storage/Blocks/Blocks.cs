namespace RawCraft.Storage.Blocks
{
    class Blocks
    {
        public static Block[] blocks;

        public static void InitialzizeBlocks()
        {
            blocks = new Block[137];
            for (int i = 0; i < blocks.Length; i++)
                blocks[i] = new Block();

            blocks[0].IsTransparent = true;


            blocks[2].IsMultitex = true;


            blocks[5].HasMetadata = true;

            blocks[6].IsEntity = true;

            blocks[8].IsEntity = true;

            blocks[9].IsEntity = true;

            blocks[10].IsEntity = true;

            blocks[11].IsEntity = true;

            blocks[17].IsMultitex = true;
            blocks[17].HasMetadata = true;

            blocks[18].IsTransparent = true;
            blocks[18].HasMetadata = true;

            blocks[20].IsTransparent = true;

            blocks[23].IsMultitex = true;

            blocks[24].IsMultitex = true;
            blocks[24].HasMetadata = true;

            blocks[25].HasMetadata = true;

            blocks[26].IsEntity = true;

            blocks[27].IsEntity = true;

            blocks[28].IsEntity = true;

            // blocks[29].HasMetadata = true; <-- enable this after fixing the vertexindexgenerator
            blocks[29].IsMultitex = true;

            blocks[30].IsEntity = true;

            blocks[31].IsEntity = true;

            blocks[32].IsEntity = true;

            blocks[33].IsMultitex = true;
            // blocks[33].HasMetadata = true; <-- enable this after fixing the vertexindexgenerator

            blocks[34].IsEntity = true;

            blocks[35].HasMetadata = true;

            blocks[36].IsEntity = true;

            blocks[37].IsEntity = true;

            blocks[38].IsEntity = true;

            blocks[39].IsEntity = true;

            blocks[40].IsEntity = true;

            blocks[43].IsMultitex = true;
            blocks[43].HasMetadata = true;

            blocks[44].IsTransparent = true;
            blocks[44].HasMetadata = true;

            blocks[46].IsMultitex = true;

            blocks[47].IsMultitex = true;


            blocks[50].IsEntity = true;

            blocks[51].IsEntity = true;

            blocks[52].IsTransparent = true;

            blocks[53].IsTransparent = true;

            blocks[54].IsEntity = true;

            blocks[55].IsEntity = true;

            blocks[58].IsMultitex = true;

            blocks[59].IsEntity = true;

            blocks[60].IsTransparent = true;
            blocks[60].IsMultitex = true;

            blocks[61].IsMultitex = true;

            blocks[62].IsMultitex = true;

            blocks[63].IsEntity = true;

            blocks[64].IsEntity = true;

            blocks[65].IsEntity = true;

            blocks[66].IsEntity = true;

            blocks[67].IsTransparent = true;
            blocks[67].HasMetadata = true;

            blocks[68].IsEntity = true;

            blocks[69].IsEntity = true;

            blocks[70].IsEntity = true;

            blocks[71].IsEntity = true;

            blocks[72].IsEntity = true;


            blocks[75].IsEntity = true;

            blocks[76].IsEntity = true;

            blocks[77].IsEntity = true;

            blocks[78].IsTransparent = true;

            blocks[79].IsEntity = true;


            blocks[81].IsEntity = true;

            blocks[83].IsEntity = true;

            blocks[84].IsMultitex = true;

            blocks[85].IsEntity = true;

            blocks[86].IsMultitex = true;


            blocks[90].IsEntity = true;

            blocks[91].IsMultitex = true;

            blocks[92].IsEntity = true;

            blocks[93].IsEntity = true;

            blocks[94].IsEntity = true;

            blocks[95].IsEntity = true;

            blocks[96].IsEntity = true;

            blocks[99].IsMultitex = true;

            blocks[100].IsMultitex = true;

            blocks[101].IsEntity = true;

            blocks[102].IsEntity = true;

            blocks[103].IsMultitex = true;

            blocks[104].IsEntity = true;

            blocks[105].IsEntity = true;

            blocks[106].IsEntity = true;

            blocks[107].IsEntity = true;

            blocks[108].IsTransparent = true;

            blocks[109].IsTransparent = true;

            blocks[110].IsMultitex = true;

            blocks[111].IsEntity = true;


            blocks[113].IsEntity = true;

            blocks[114].IsTransparent = true;

            blocks[115].IsEntity = true;

            blocks[116].IsEntity = true;

            blocks[117].IsEntity = true;

            blocks[118].IsEntity = true;

            blocks[119].IsEntity = true;

            blocks[120].IsEntity = true;


            blocks[122].IsEntity = true;


            blocks[126].IsTransparent = true;

            blocks[127].IsEntity = true;

            blocks[128].IsTransparent = true;


            blocks[130].IsEntity = true;

            blocks[131].IsEntity = true;

            blocks[132].IsEntity = true;


            blocks[134].IsTransparent = true;

            blocks[135].IsTransparent = true;

            blocks[136].IsTransparent = true;
        }
    }
}
