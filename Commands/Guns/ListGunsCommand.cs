using System;
using System.Collections.Generic;
using CounterStrike.Guns;
using CounterStrike.Players;
using Microsoft.Xna.Framework;
using SourceEngineConsole.Commands;
using Terraria;
using Terraria.ModLoader;

namespace CounterStrike.Commands.Guns
{
    public class ListGunsCommand : SourceEngineCommand
    {
        public const string COMMAND = "cs_guns";


        public ListGunsCommand() : base(COMMAND, CommandType.Chat)
        {
        }


        protected override void Run(CommandCaller caller, Player player, string input, string[] args)
        {
            List<string> guns = new List<string>();

            CSPlayer csPlayer = CSPlayer.Get(player);

            if (args.Length == 0)
                GunDefinitionsManager.Instance.ForAll(g => guns.Add(g.UnlocalizedName));
            else if (args[0].Equals("-a", StringComparison.CurrentCultureIgnoreCase))
                GunDefinitionsManager.Instance.ForAll(g =>
                {
                    if (g.Price <= csPlayer.Money)
                        guns.Add(g.UnlocalizedName);
                });

            Main.NewText(string.Join(", ", guns));
        }


        public override string Usage { get; } = $"{COMMAND} : lists guns\n{COMMAND} -a : lists only available guns";
    }
}