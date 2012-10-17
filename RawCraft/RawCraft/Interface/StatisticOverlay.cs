using Microsoft.Xna.Framework;
using RawCraft.Interface.BaseClasses;
using RawCraft.Storage;
using Microsoft.Xna.Framework.Graphics;

namespace RawCraft.Interface
{
    class StatisticOverlay : TextOverlay
    {
        FPSCounter counter;
        public StatisticOverlay(SpriteFont font, Vector2 vec) : base(font, vec)
        {
        }

        public void UpdateText(GameTime gameTime)
        {
            if (counter == null)
                counter = new FPSCounter(gameTime);

            base.UpdateText(
                "FPS: " + counter.FPS +
                "\nDraw time (in ms): " + counter.DrawTime +
                "\nX: " + Player.X +
                "\nY: " + Player.Y +
                "\nZ: " + Player.Z +
                "\nPitch: " + Player.Pitch +
                "\nYaw: " + Player.Yaw +
                "\nRenderQueue: " + Renderer.RenderFIFO.Count +
                "\nRender Time: " + Misc.RendertimeCounter.ElapsedMilliseconds);
        }

        public void Draw()
        {
            counter.UpdateFPS();
            base.Draw(Misc.spriteBatch);
        }
    }
}
