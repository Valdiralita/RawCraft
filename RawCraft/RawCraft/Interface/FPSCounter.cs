using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace RawCraft.Interface
{
    class FPSCounter
    {
        int fps, fpscounter, time, drawtime;
        Stopwatch stop;
        GameTime gameTime;

        public FPSCounter(GameTime gt)
        {
            gameTime = gt;
            stop = new Stopwatch();
        }

        public void UpdateFPS()
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
            if (time >= 1000)
            {
                fps = fpscounter;
                fpscounter = 0;
                time = time % 1000;
            }

            drawtime = (int)stop.ElapsedMilliseconds;
            stop.Restart();

            fpscounter++;
        }

        public int FPS
        {
            get 
            {
               return fps; 
            }
        }

        public int DrawTime
        {
            get 
            {
               return drawtime; 
            }
        }
    }
}
