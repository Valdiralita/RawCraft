using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Storage;
using Microsoft.Xna.Framework;

namespace Menu
{
    class Background
    {
        Texture2D Texture;
        int horizontalTileCount, verticalTileCount;

        public Background(Texture2D texture)
        {
            Texture = texture;
        }

        public void SetTexture(Texture2D tex)
        {
            Texture = tex;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            horizontalTileCount = Misc.Width / Texture.Width + 1;
            verticalTileCount = Misc.Height / Texture.Height + 1;

            for (int i = 0; i < horizontalTileCount; i++)
            {
                for (int j = 0; j < verticalTileCount; j++)
                {
                    spriteBatch.Draw(Texture, new Vector2(Texture.Width * i, Texture.Height * j), Color.White);
                }
            }
        }
    }
}
