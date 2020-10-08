using System;
using System.Collections.Generic;
using CounterStrike.Guns;
using CounterStrike.Players;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Commands;

namespace CounterStrike.Commands.Guns
{
    public class ListGunsCommand : StandardCommand
    {
        public const string COMMAND = "cs_guns";


        public ListGunsCommand() : base(COMMAND, CommandType.Chat)
        {
        }


        protected override void ActionLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            List<string> guns = new List<string>();

            CSPlayer csPlayer = CSPlayer.Get(player);

            if (args.Length == 0)
                GunDefinitions.Instance.ForAllGeneric(g => guns.Add(g.UnlocalizedName));

            else if (args[0].Equals("-a", StringComparison.CurrentCultureIgnoreCase))
                GunDefinitions.Instance.ForAllGeneric(g =>
                {
                    if (g.Price <= csPlayer.Money)
                        guns.Add(g.UnlocalizedName);
                });

            Main.NewText(string.Join(", ", guns));
        }


        public override string Usage { get; } = $"{COMMAND} : lists guns\n{COMMAND} -a : lists only available guns";
    }
}