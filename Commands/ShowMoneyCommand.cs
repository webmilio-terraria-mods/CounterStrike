using CounterStrike.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Commands;
using WebmilioCommons.Extensions;

namespace CounterStrike.Commands
{
    public class ShowMoneyCommand : StandardCommand
    {
        public ShowMoneyCommand() : base("cs_money", CommandType.Chat)
        {
        }


        protected override void ActionLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            CSPlayer csPlayer = CSPlayer.Get(player);

            Color textColor = csPlayer.Money > 0 ? Color.Green : csPlayer.Money == 0 ? Color.White : Color.Red;
            Main.NewText("Current money: " + csPlayer.Money, textColor);
        }
    }
}