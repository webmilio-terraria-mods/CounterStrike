using System;
using CounterStrike.Guns;
using CounterStrike.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Commands;

namespace CounterStrike.Commands.Guns
{
    public class BuyGunCommand : StandardCommand
    {
        private const string COMMAND = "cs_buy";


        public BuyGunCommand() : base(COMMAND, CommandType.Chat)
        {
        }


        protected override void ActionLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            if (args.Length == 0)
            {
                Main.NewText(Usage, Color.Red);
                return;
            }


            GunDefinition definition = GunDefinitions.Instance.FindGeneric(g => g.UnlocalizedName.Equals(args[0], StringComparison.CurrentCultureIgnoreCase));
            if (definition == default)
            {
                Main.NewText($"Gun name '{args[0]} is invalid. Use /cs_guns for a list of guns.");
                return;
            }


            CSPlayer csPlayer = CSPlayer.Get(player);

            if (csPlayer.Money < definition.Price)
            {
                Main.NewText($"Specified gun '{args[0]}' is too costly. Use /cs_guns -a for a list of guns you can buy.");
                return;
            }


            csPlayer.TryBuyGun(definition);
        }


        public override string Usage { get; } = $"{COMMAND} <gun name> : buy specified gun";
    }
}