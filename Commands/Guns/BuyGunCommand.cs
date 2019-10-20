using CounterStrike.Guns;
using CounterStrike.Players;
using Microsoft.Xna.Framework;
using SourceEngineConsole.Commands;
using Terraria;
using Terraria.ModLoader;

namespace CounterStrike.Commands.Guns
{
    public class BuyGunCommand : SourceEngineCommand
    {
        private const string COMMAND = "cs_buy";


        public BuyGunCommand() : base(COMMAND, CommandType.Chat)
        {
        }


        protected override void Run(CommandCaller caller, Player player, string input, string[] args)
        {
            GunDefinition gun = null;

            if (args.Length == 0)
            {
                Main.NewText(Usage, Color.Red);
                return;
            }

            args[0] = args[0].ToLower();


            if (!GunDefinitionsManager.Instance.Contains(args[0]))
            {
                Main.NewText($"Gun name '{args[0]} is invalid. Use /cs_guns for a list of guns.");
                return;
            }

            gun = GunDefinitionsManager.Instance[args[0]];


            CSPlayer csPlayer = CSPlayer.Get(player);

            if (csPlayer.Money < gun.Price)
            {
                Main.NewText($"Specified gun '{args[0]}' is too costly. Use /cs_guns -a for a list of guns you can buy.");
                return;
            }


            csPlayer.TryBuyGun(gun);
        }


        public override string Usage { get; } = $"{COMMAND} <gun name> : buy specified gun";
    }
}