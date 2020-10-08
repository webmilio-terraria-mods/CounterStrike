using CounterStrike.Guns;
using CounterStrike.Players;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace CounterStrike.UserInterfaces.BuyMenu
{
    public class BuyOption : BuyMenuButton
    {
        public BuyOption(string optionName, GunDefinition gun) : base(optionName, gun)
        {
            Gun = gun;
        }

        public override void Click(UIMouseEvent evt)
        {
            CSPlayer.Get().UIBuyGun(Gun);
        }

        public GunDefinition Gun { get; }
    }
}
