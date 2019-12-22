using System;
using System.Collections.Generic;
using CounterStrike.Guns;
using CounterStrike.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Commands;

namespace CounterStrike.Commands.Guns
{
    public class AmmoCommand : StandardCommand
    {
        public const string COMMAND = "cs_ammo";


        public AmmoCommand() : base(COMMAND, CommandType.Chat)
        {
        }


        protected override void ActionLocal(CommandCaller caller, Player player, string input, string[] args)
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
                GunDefinition definition = GunDefinitionLoader.Instance.FindGeneric(g => g.UnlocalizedName.Equals(args[0], StringComparison.CurrentCultureIgnoreCase));

                if (definition == default)
                {
                    Main.NewText($"Specified gun `{args[0]}` doesn't exist.", Color.Red);
                    return;
                }

                Main.NewText($"{definition.UnlocalizedName}:{csPlayer.GetAmmoCount(definition)}");
            }
        }


        public override string Usage { get; } = $"{COMMAND} <gun name> : lists how much owned ammo for specified gun\n" +
                                                $"{COMMAND} -a : lists all owned ammo for each gun purchased this playthrough";
    }
}