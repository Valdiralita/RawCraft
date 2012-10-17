using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Renderer
{
    static class VertexPositions
    {
        public static List<Vector3>[] Block;
        public static List<Vector3> Plant;

        // public static List<Vector3>[] HalfBlock = new List<Vector3>;
        // public static List<Vector3>[] Stairs = new List<Vector3>;
        // public static List<Vector3>[] Plant = new List<Vector3>;
        // public static List<Vector3>[] Torch = new List<Vector3>;

        public static void Initialize()
        {
            // 0 = z+
            // 1 = z-
            // 2 = x+
            // 3 = x-
            // 4 = y+
            // 5 = y-
            Block = new List<Vector3>[6];

            Block[0] = new List<Vector3>();

            Block[0].Add(new Vector3(0.5f, 0.5f, 0.5f));
            Block[0].Add(new Vector3(-0.5f, 0.5f, 0.5f));
            Block[0].Add(new Vector3(-0.5f, -0.5f, 0.5f));
            Block[0].Add(new Vector3(0.5f, -0.5f, 0.5f));

            Block[1] = new List<Vector3>();
            Block[1].Add(new Vector3(-0.5f, 0.5f, -0.5f));
            Block[1].Add(new Vector3(0.5f, 0.5f, -0.5f));
            Block[1].Add(new Vector3(0.5f, -0.5f, -0.5f));
            Block[1].Add(new Vector3(-0.5f, -0.5f, -0.5f));


            Block[2] = new List<Vector3>();
            Block[2].Add(new Vector3(0.5f, 0.5f, -0.5f));
            Block[2].Add(new Vector3(0.5f, 0.5f, 0.5f));
            Block[2].Add(new Vector3(0.5f, -0.5f, 0.5f));
            Block[2].Add(new Vector3(0.5f, -0.5f, -0.5f));

            Block[3] = new List<Vector3>();
            Block[3].Add(new Vector3(-0.5f, 0.5f, 0.5f));
            Block[3].Add(new Vector3(-0.5f, 0.5f, -0.5f));
            Block[3].Add(new Vector3(-0.5f, -0.5f, -0.5f));
            Block[3].Add(new Vector3(-0.5f, -0.5f, 0.5f));


            Block[4] = new List<Vector3>();
            Block[4].Add(new Vector3(-0.5f, 0.5f, -0.5f));
            Block[4].Add(new Vector3(-0.5f, 0.5f, 0.5f));
            Block[4].Add(new Vector3(0.5f, 0.5f, 0.5f));
            Block[4].Add(new Vector3(0.5f, 0.5f, -0.5f));

            Block[5] = new List<Vector3>();
            Block[5].Add(new Vector3(0.5f, -0.5f, -0.5f));
            Block[5].Add(new Vector3(0.5f, -0.5f, 0.5f));
            Block[5].Add(new Vector3(-0.5f, -0.5f, 0.5f));
            Block[5].Add(new Vector3(-0.5f, -0.5f, -0.5f));






            Plant = new List<Vector3>();

            Plant.Add(new Vector3((float)(-Math.Sqrt(2) / 4),  0.5f, (float)(-Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)( Math.Sqrt(2) / 4),  0.5f, (float)( Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)( Math.Sqrt(2) / 4), -0.5f, (float)( Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)(-Math.Sqrt(2) / 4), -0.5f, (float)(-Math.Sqrt(2) / 4)));
                                                                                             
            Plant.Add(new Vector3((float)( Math.Sqrt(2) / 4),  0.5f, (float)( Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)(-Math.Sqrt(2) / 4),  0.5f, (float)(-Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)(-Math.Sqrt(2) / 4), -0.5f, (float)(-Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)( Math.Sqrt(2) / 4), -0.5f, (float)( Math.Sqrt(2) / 4)));
                                                                                             
            Plant.Add(new Vector3((float)(-Math.Sqrt(2) / 4),  0.5f, (float)( Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)( Math.Sqrt(2) / 4),  0.5f, (float)(-Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)( Math.Sqrt(2) / 4), -0.5f, (float)(-Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)(-Math.Sqrt(2) / 4), -0.5f, (float)( Math.Sqrt(2) / 4)));
                                                                                             
            Plant.Add(new Vector3((float)( Math.Sqrt(2) / 4),  0.5f, (float)(-Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)(-Math.Sqrt(2) / 4),  0.5f, (float)( Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)(-Math.Sqrt(2) / 4), -0.5f, (float)( Math.Sqrt(2) / 4)));
            Plant.Add(new Vector3((float)( Math.Sqrt(2) / 4), -0.5f, (float)(-Math.Sqrt(2) / 4)));
        }
    }
}






//public static void Initialize()
//{
//    // 0 = z+
//    // 1 = z-
//    // 2 = x+
//    // 3 = x-
//    // 4 = y+
//    // 5 = y-
//    Block = new List<Vector3>[6];

//    Block[0] = new List<Vector3>();

//    Block[0].Add(new Vector3(0.5f, 0.5f, 0.5f));
//    Block[0].Add(new Vector3(-0.5f, 0.5f, 0.5f));
//    Block[0].Add(new Vector3(-0.5f, -0.5f, 0.5f));
//    Block[0].Add(new Vector3(0.5f, -0.5f, 0.5f));

//    Block[1] = new List<Vector3>();
//    Block[1].Add(new Vector3(-0.5f, 0.5f, -0.5f));
//    Block[1].Add(new Vector3(0.5f, 0.5f, -0.5f));
//    Block[1].Add(new Vector3(0.5f, -0.5f, -0.5f));
//    Block[1].Add(new Vector3(-0.5f, -0.5f, -0.5f));


//    Block[2] = new List<Vector3>();
//    Block[2].Add(new Vector3(0.5f, 0.5f, -0.5f));
//    Block[2].Add(new Vector3(0.5f, 0.5f, 0.5f));
//    Block[2].Add(new Vector3(0.5f, -0.5f, 0.5f));
//    Block[2].Add(new Vector3(0.5f, -0.5f, -0.5f));

//    Block[3] = new List<Vector3>();
//    Block[3].Add(new Vector3(-0.5f, 0.5f, 0.5f));
//    Block[3].Add(new Vector3(-0.5f, 0.5f, -0.5f));
//    Block[3].Add(new Vector3(-0.5f, -0.5f, -0.5f));
//    Block[3].Add(new Vector3(-0.5f, -0.5f, 0.5f));


//    Block[4] = new List<Vector3>();
//    Block[4].Add(new Vector3(-0.5f, 0.5f, -0.5f));
//    Block[4].Add(new Vector3(-0.5f, 0.5f, 0.5f));
//    Block[4].Add(new Vector3(0.5f, 0.5f, 0.5f));
//    Block[4].Add(new Vector3(0.5f, 0.5f, -0.5f));

//    Block[5] = new List<Vector3>();
//    Block[5].Add(new Vector3(0.5f, -0.5f, -0.5f));
//    Block[5].Add(new Vector3(0.5f, -0.5f, 0.5f));
//    Block[5].Add(new Vector3(-0.5f, -0.5f, 0.5f));
//    Block[5].Add(new Vector3(-0.5f, -0.5f, -0.5f));







//    Plant = new List<Vector3>();

//    Plant.Add(new Vector3(-0.5f, 0.5f, -0.5f));
//    Plant.Add(new Vector3(0.5f, 0.5f, 0.5f));
//    Plant.Add(new Vector3(0.5f, -0.5f, 0.5f));
//    Plant.Add(new Vector3(-0.5f, -0.5f, -0.5f));

//    Plant.Add(new Vector3(0.5f, 0.5f, 0.5f));
//    Plant.Add(new Vector3(-0.5f, 0.5f, -0.5f));
//    Plant.Add(new Vector3(-0.5f, -0.5f, -0.5f));
//    Plant.Add(new Vector3(0.5f, -0.5f, 0.5f));

//    Plant.Add(new Vector3(-0.5f, 0.5f, 0.5f));
//    Plant.Add(new Vector3(0.5f, 0.5f, -0.5f));
//    Plant.Add(new Vector3(0.5f, -0.5f, -0.5f));
//    Plant.Add(new Vector3(-0.5f, -0.5f, 0.5f));

//    Plant.Add(new Vector3(0.5f, 0.5f, -0.5f));
//    Plant.Add(new Vector3(-0.5f, 0.5f, 0.5f));
//    Plant.Add(new Vector3(-0.5f, -0.5f, 0.5f));
//    Plant.Add(new Vector3(0.5f, -0.5f, -0.5f));





//}

