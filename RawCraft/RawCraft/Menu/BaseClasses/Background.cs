using Microsoft.Xna.Framework.Graphics;
using RawCraft.Storage;
using Microsoft.Xna.Framework;

namespace RawCraft.Menu.BaseClasses
{
    class Background
    {
        Texture2D texture;
        int horizontalTileCount, verticalTileCount;

        public Background(Texture2D texture)
        {
            this.texture = texture;
        }

        public void SetTexture(Texture2D tex)
        {
            texture = tex;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            horizontalTileCount = Misc.Width / texture.Width + 1;
            verticalTileCount = Misc.Height / texture.Height + 1;

            for (int i = 0; i < horizontalTileCount; i++)
            {
                for (int j = 0; j < verticalTileCount; j++)
                    spriteBatch.Draw(texture, new Vector2(texture.Width * i, texture.Height * j), Color.White);
            }
        }
    }
}
