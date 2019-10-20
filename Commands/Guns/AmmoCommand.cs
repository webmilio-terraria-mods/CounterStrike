using System.Collections.Generic;
using CounterStrike.Guns;
using CounterStrike.Players;
using Microsoft.Xna.Framework;
using SourceEngineConsole.Commands;
using Terraria;
using Terraria.ModLoader;

namespace CounterStrike.Commands.Guns
{
    public class AmmoCommand : SourceEngineCommand
    {
        public const string COMMAND = "cs_ammo";


        public AmmoCommand() : base(COMMAND, CommandType.Chat)
        {
        }


        protected override void RunLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            CSPlayer csPlayer = CSPlayer.Get(player);

            if (args.Length == 0)
            {
                Main.NewTextMultiline(Usage, c: Color.Red);
                return;
            }

            args[0] = args[0].ToLower();

            if (args[0].Equals("-a"))
            {
                List<string> ammo = new List<string>();

                foreach (GunDefinition gun in csPlayer.OwnedAmmo())
                    ammo.Add($"{gun.UnlocalizedName}:{csPlayer.GetAmmoCount(gun)}");
            }
            else
            {
                if (!GunDefinitionsManager.Instance.TryGet(args[0], out GunDefinition gun))
                {
                    Main.NewText($"Specified gun `{args[0]}` doesn't exist.", Color.Red);
                    return;
                }

                if (!csPlayer.HasPurchasedThisSession(gun))
                {
                    Main.NewText("You haven't purchased this gun or any ammo for this gun this session!", Color.Red);
                    return;
                }

                Main.NewText($"{gun.UnlocalizedName}:{csPlayer.GetAmmoCount(gun)}");
            }
        }


        public override string Usage { get; } = $"{COMMAND} <gun name> : lists how much owned ammo for specified gun\n" +
                                                $"{COMMAND} -a : lists all owned ammo for each gun purchased this playthrough";
    }
}