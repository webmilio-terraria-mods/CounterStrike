using CounterStrike.Players;
using SourceEngineConsole.Commands;
using Terraria;
using Terraria.ModLoader;

namespace CounterStrike.Commands
{
    public class GiveMoneyCommand : SourceEngineCommand
    {
        public GiveMoneyCommand() : base("cs_givemoney", CommandType.Chat)
        {
        }


        protected override void RunLocal(CommandCaller caller, Player player, string input, string[] args)
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