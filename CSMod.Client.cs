using System.Collections.Generic;
using CounterStrike.UserInterfaces.BuyMenu;
using CounterStrike.UserInterfaces.KillFeed;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;
using Terraria.UI;

namespace CounterStrike
{
    public sealed partial class CSMod
    {
        private void LoadClient()
        {
            KillFeedLayer = new KillFeedLayer(new KillFeedUIState());
            BuyLayer = new BuyLayer(new BuyMenuState());

            Reload = RegisterHotKey("Reload", Keys.G.ToString());
            OpenBuyMenu = RegisterHotKey("Open buy menu", Keys.NumPad0.ToString());
        }

        private void UnloadClient()
        {
            Reload = null;
            OpenBuyMenu = null;
        }


        public override void UpdateUI(GameTime gameTime)
        {
            BuyLayer?.Update(gameTime);
            KillFeedLayer?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            layers.Add(KillFeedLayer);

            int index = layers.FindIndex(x => x.Name == "Vanilla: Mouse Text");

            layers.Insert(index, BuyLayer);
        }


        public KillFeedLayer KillFeedLayer { get; private set; }

        public BuyLayer BuyLayer { get; private set; }

        public ModHotKey Reload { get; private set; }

        public ModHotKey OpenBuyMenu { get; private set; }
    }
}
