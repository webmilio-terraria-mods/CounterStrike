using CounterStrike.Players;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Commands;

namespace CounterStrike.Commands
{
    public class GiveMoneyCommand : StandardCommand
    {
        public GiveMoneyCommand() : base("cs_givemoney", CommandType.Chat)
        {
        }


        protected override void ActionLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            CSPlayer csPlayer = CSPlayer.Get(player);

            if (args.Length == 0)
                return;

            if (!int.TryParse(args[0], out int money))
                return;

            csPlayer.ModifyMoney(money);
        }
    }
}