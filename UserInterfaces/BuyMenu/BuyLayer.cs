using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;

namespace CounterStrike.UserInterfaces.BuyMenu
{
    public class BuyLayer : GameInterfaceLayer
    {
        public BuyLayer(BuyMenuState state) : base("CounterStrike: Buy Menu", InterfaceScaleType.UI)
        {
            BuyUIState = state;
        }


        public void Update(GameTime gameTime)
        {
            BuyUIState?.Update(gameTime);
        }

        protected override bool DrawSelf()
        {
            if(BuyUIState != null && BuyUIState.Visible)
                BuyUIState?.Draw(Main.spriteBatch);

            return true;
        }


        public BuyMenuState BuyUIState { get; } 
    }
}
