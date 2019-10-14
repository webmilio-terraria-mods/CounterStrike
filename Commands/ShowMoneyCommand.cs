using CounterStrike.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace CounterStrike.Commands
{
    public class ShowMoneyCommand : ModCommand
    {
        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Player player = caller.Player;

            if (player != null && player.IsLocalPlayer())
            {
                CSPlayer csPlayer = CSPlayer.Get(player);

                Color textColor = csPlayer.Money > 0 ? Color.Green : csPlayer.Money == 0 ? Color.White : Color.Red;
                Main.NewText("Current money: " + csPlayer.Money, textColor);
            }
        }

        
        public override string Command { get; } = "cs_showmoney";
        public override CommandType Type { get; } = CommandType.Chat;
    }
}