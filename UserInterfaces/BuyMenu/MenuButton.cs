using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;

namespace CounterStrike.UserInterfaces.BuyMenu
{
    public class MenuButton : UIImageButton
    {
        public MenuButton(string optionName) : base(Main.magicPixel)
        {
            OptionName = optionName;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            DrawBorderedRectangle(this.GetDimensions().Position(), (int)this.Width.Pixels, (int)this.Height.Pixels, IsMouseHovering ? Color.Red * 0.5f : Color.Black * 0.5f, Color.Orange, spriteBatch);
            spriteBatch.DrawString(Main.fontMouseText, OptionName, this.GetDimensions().Position() + new Vector2(6, this.Height.Pixels - 28), Color.Orange);

            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);

            if (this.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
        }


        // Copy pasted from my attempt at making an RTS
        public void DrawBorderedRectangle(Vector2 position, int width, int height, Color color, Color borderColor, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw
                 (
                     Main.magicPixel,
                     position,
                     new Rectangle(0, 0, width, height),
                     color,
                     0f,
                     Vector2.Zero,
                     1f,
                     SpriteEffects.None,
                     1
                 );

            #region Draw Borders
            spriteBatch.Draw
                     (
                         Main.magicPixel,
                         position,
                         new Rectangle(0, 0, 2, height),
                         borderColor,
                         0f,
                         Vector2.Zero,
                         1f,
                         SpriteEffects.None,
                         1
                     );
            spriteBatch.Draw
                     (
                         Main.magicPixel,
                         position,
                         new Rectangle(0, 0, width, 2),
                         borderColor,
                         0f,
                         Vector2.Zero,
                         1f,
                         SpriteEffects.None,
                         1
                     );
            spriteBatch.Draw
                     (
                         Main.magicPixel,
                         position + new Vector2(width - 2, 0),
                         new Rectangle(0, 0, 2, height),
                         borderColor,
                         0f,
                         Vector2.Zero,
                         1f,
                         SpriteEffects.None,
                         1
                     );
            spriteBatch.Draw
                     (
                         Main.magicPixel,
                         position + new Vector2(0, height - 2),
                         new Rectangle(0, 0, width, 2),
                         borderColor,
                         0f,
                         Vector2.Zero,
                         1f,
                         SpriteEffects.None,
                         1
                     );
            #endregion
        }

        public string OptionName { get; set; }
    }
}
