using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RawCraft.Renderer
{
    static class VertexPositions
    {
        public static List<Vector3>[] Block;
        public static List<Vector3> XSprite;

        public static void Initialize()
        {
            // 0 = z+
            // 1 = z-
            // 2 = x+
            // 3 = x-
            // 4 = y+
            // 5 = y-
            Block = new List<Vector3>[6];

            Block[0] = new List<Vector3>
                {
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, 0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f)
                };

            Block[1] = new List<Vector3>
                {
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, -0.5f),
                    new Vector3(-0.5f, -0.5f, -0.5f)
                };

            Block[2] = new List<Vector3>
                {
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f),
                    new Vector3(0.5f, -0.5f, -0.5f)
                };

            Block[3] = new List<Vector3>
                {
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(-0.5f, -0.5f, -0.5f),
                    new Vector3(-0.5f, -0.5f, 0.5f)
                };

            Block[4] = new List<Vector3>
                {
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f)
                };

            Block[5] = new List<Vector3>
                {
                    new Vector3(0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, -0.5f)
                };


            XSprite = new List<Vector3>
                {
                    new Vector3((float) (-Math.Sqrt(2)/4), 0.5f, (float) (-Math.Sqrt(2)/4)),
                    new Vector3((float) (Math.Sqrt(2)/4), 0.5f, (float) (Math.Sqrt(2)/4)),
                    new Vector3((float) (Math.Sqrt(2)/4), -0.5f, (float) (Math.Sqrt(2)/4)),
                    new Vector3((float) (-Math.Sqrt(2)/4), -0.5f, (float) (-Math.Sqrt(2)/4)),
                    new Vector3((float) (Math.Sqrt(2)/4), 0.5f, (float) (Math.Sqrt(2)/4)),
                    new Vector3((float) (-Math.Sqrt(2)/4), 0.5f, (float) (-Math.Sqrt(2)/4)),
                    new Vector3((float) (-Math.Sqrt(2)/4), -0.5f, (float) (-Math.Sqrt(2)/4)),
                    new Vector3((float) (Math.Sqrt(2)/4), -0.5f, (float) (Math.Sqrt(2)/4)),
                    new Vector3((float) (-Math.Sqrt(2)/4), 0.5f, (float) (Math.Sqrt(2)/4)),
                    new Vector3((float) (Math.Sqrt(2)/4), 0.5f, (float) (-Math.Sqrt(2)/4)),
                    new Vector3((float) (Math.Sqrt(2)/4), -0.5f, (float) (-Math.Sqrt(2)/4)),
                    new Vector3((float) (-Math.Sqrt(2)/4), -0.5f, (float) (Math.Sqrt(2)/4)),
                    new Vector3((float) (Math.Sqrt(2)/4), 0.5f, (float) (-Math.Sqrt(2)/4)),
                    new Vector3((float) (-Math.Sqrt(2)/4), 0.5f, (float) (Math.Sqrt(2)/4)),
                    new Vector3((float) (-Math.Sqrt(2)/4), -0.5f, (float) (Math.Sqrt(2)/4)),
                    new Vector3((float) (Math.Sqrt(2)/4), -0.5f, (float) (-Math.Sqrt(2)/4))
                };
        }
    }
}
