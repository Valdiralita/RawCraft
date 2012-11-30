using Microsoft.Xna.Framework;
using RawCraft.Interface.BaseClasses;
using RawCraft.Renderer;
using RawCraft.Storage;
using Microsoft.Xna.Framework.Graphics;

namespace RawCraft.Interface
{
    class StatisticOverlay : TextOverlay
    {
        FPSCounter _counter;
        public StatisticOverlay(SpriteFont font, Vector2 vec) : base(font, vec)
        {
        }

        public void UpdateText(GameTime gameTime)
        {
            if (_counter == null)
                _counter = new FPSCounter(gameTime);

            base.UpdateText(
                "FPS: " + _counter.FPS +
                "\nDraw time (in ms): " + _counter.DrawTime +
                "\nX: " + Player.X +
                "\nY: " + Player.Y +
                "\nZ: " + Player.Z +
                "\nPitch: " + Player.Pitch +
                "\nYaw: " + Player.Yaw +
                "\nRenderQueue: " + RenderFIFO.Count +
                "\nRender Time: " + Debug.RendertimeCounter.ElapsedMilliseconds);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_counter != null)
            {
                _counter.UpdateFPS();
                base.Draw(spriteBatch);
            }
        }
    }
}
