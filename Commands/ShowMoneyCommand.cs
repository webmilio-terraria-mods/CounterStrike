using CounterStrike.Players;
using Microsoft.Xna.Framework;
using SourceEngineConsole.Commands;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace CounterStrike.Commands
{
    public class ShowMoneyCommand : SourceEngineCommand
    {
        public ShowMoneyCommand() : base("cs_money", CommandType.Chat)
        {
        }


        protected override void Run(CommandCaller caller, Player player, string input, string[] args)
        {
            if (player.IsLocalPlayer())
            {
                CSPlayer csPlayer = CSPlayer.Get(player);

                Color textColor = csPlayer.Money > 0 ? Color.Green : csPlayer.Money == 0 ? Color.White : Color.Red;
                Main.NewText("Current money: " + csPlayer.Money, textColor);
            }
        }
    }
}