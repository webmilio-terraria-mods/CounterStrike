using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.UI;

namespace CounterStrike.UserInterfaces.KillFeed
{
    public class KillFeedElement : UIElement
    {
        public KillFeedElement()
        {
            KillFeedEntries = new List<KillFeedEntry>();
        }


        public void UpdateFeed(GameTime gameTime)
        {
            foreach (KillFeedEntry entry in KillFeedEntries)
            {
                entry.Update();
                entry.YOffset = 20 + KillFeedEntries.IndexOf(entry) * 42;
            }

            for (int i = KillFeedEntries.Count - 1; i >= 0; i--)
                if (KillFeedEntries[i].ExistsFor >= KillFeedEntry.MAX_EXISTANCE_TIME)
                    KillFeedEntries.RemoveAt(i);

            base.Update(gameTime);
        }


        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            foreach(KillFeedEntry entry in KillFeedEntries)
            {
                if (entry.ExistsFor < 2)
                    continue;

                spriteBatch.Draw(Main.magicPixel, entry.Position, new Rectangle(0, 0, 400, 38), Color.Black * 0.33f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

                spriteBatch.DrawString(Main.fontMouseText, entry.KillerName, entry.Position + new Vector2(10, 10), Color.White);
                spriteBatch.DrawString(Main.fontMouseText, entry.VictimName, entry.Position + new Vector2(260, 10), Color.White);
            }
        }


        public List<KillFeedEntry> KillFeedEntries { get; }
    }
}
