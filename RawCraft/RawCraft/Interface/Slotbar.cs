using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RawCraft.Storage;
using Microsoft.Xna.Framework.Content;

namespace RawCraft.Interface
{
    class Slotbar
    {
        Texture2D SlotbarTexture;
        Vector2 SlotbarPosition;

        public Slotbar(ContentManager Content, int x, int y)
        {
            SlotbarTexture = Content.Load<Texture2D>("Slotbar");
            SlotbarPosition = new Vector2(x / 2 - SlotbarTexture.Width / 2, y - SlotbarTexture.Height);
        }

        public void UpdateSlotbar(GameTime gameTime)
        {

        }

        public void DrawSlotbar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SlotbarTexture, SlotbarPosition, Color.White);
        }
    }
}
