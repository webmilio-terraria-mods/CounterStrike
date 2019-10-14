using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;

namespace CounterStrike.UserInterfaces.KillFeed
{
    public class KillFeedLayer : GameInterfaceLayer
    {
        public KillFeedLayer(KillFeedUIState state) : base("CounterStrike: Kill Feed", InterfaceScaleType.UI)
        {
            KillFeedUIState = state;
        }


        public void Update(GameTime gameTime)
        {
            KillFeedUIState?.Update(gameTime);
        }

        protected override bool DrawSelf()
        {
            KillFeedUIState?.Draw(Main.spriteBatch);

            return true;
        }


        public KillFeedUIState KillFeedUIState { get; } 
    }
}
