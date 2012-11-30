using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace RawCraft.Interface
{
    class FPSCounter
    {
        int _fps, _fpscounter, _time, _drawtime;
        Stopwatch _stop;
        GameTime _gameTime;

        public FPSCounter(GameTime gt)
        {
            _gameTime = gt;
            _stop = new Stopwatch();
        }

        public void UpdateFPS()
        {
            _time += _gameTime.ElapsedGameTime.Milliseconds;
            if (_time >= 1000)
            {
                _fps = _fpscounter;
                _fpscounter = 0;
                _time = _time % 1000;
            }

            _drawtime = (int)_stop.ElapsedMilliseconds;
            _stop.Restart();

            _fpscounter++;
        }

        public int FPS
        {
            get 
            {
               return _fps; 
            }
        }

        public int DrawTime
        {
            get 
            {
               return _drawtime; 
            }
        }
    }
}
