using CounterStrike.Guns;
using CounterStrike.Players;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace CounterStrike.UserInterfaces.BuyMenu
{
    public class BuyOption : MenuButton
    {
        public BuyOption(string optionName, GunDefinition gunToBuy) : base(optionName)
        {
            Gun = gunToBuy;
        }

        public override void Click(UIMouseEvent evt)
        {
            CSPlayer cPlayer = CSPlayer.Get();
            cPlayer.TryBuyGun(Gun);
        }

        public GunDefinition Gun { get; }
    }
}
