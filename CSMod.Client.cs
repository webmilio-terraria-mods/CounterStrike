using System.Collections.Generic;
using CounterStrike.UserInterfaces.KillFeed;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace CounterStrike
{
    public sealed partial class CSMod
    {
        private void LoadClient()
        {
            KillFeedLayer = new KillFeedLayer(new KillFeedUIState());

            Reload = RegisterHotKey("Reload", Keys.G.ToString());
        }

        private void UnloadClient()
        {
            Reload = null;
        }


        public override void UpdateUI(GameTime gameTime)
        {
            KillFeedLayer?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            layers.Add(KillFeedLayer);
        }


        public KillFeedLayer KillFeedLayer { get; private set; }

        public ModHotKey Reload { get; private set; }
    }
}
