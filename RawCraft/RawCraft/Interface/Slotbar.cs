using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RawCraft.Interface
{
    class Slotbar
    {
        Texture2D _slotbarTexture;
        Vector2 _slotbarPosition;

        public Slotbar(ContentManager content, int x, int y)
        {
            _slotbarTexture = content.Load<Texture2D>("Slotbar");
            _slotbarPosition = new Vector2(x / 2 - _slotbarTexture.Width / 2, y - _slotbarTexture.Height);
        }

        public void UpdateSlotbar(GameTime gameTime)
        {

        }

        public void DrawSlotbar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_slotbarTexture, _slotbarPosition, Color.White);
        }
    }
}
