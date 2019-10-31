using CounterStrike.Guns;
using CounterStrike.NPCs;
using Microsoft.Xna.Framework;
using SourceEngineConsole.Commands;
using Terraria;
using Terraria.ModLoader;

namespace CounterStrike.Commands.Debug
{
    public class ReloadGunDefinitions : SourceEngineCommand
    {
        public ReloadGunDefinitions() : base("cs_reloadgundefs", CommandType.Chat)
        {
        }


        protected override void RunLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            Main.NewText("Unloading CS Gun Definitions...");
            GunDefinitionsManager.Instance.Unload();

            Main.NewText("Loading CS Gun Definitions...");
            GunDefinitionsManager.Instance.DefaultInitialize();

            Main.NewText("Reload complete.");
        }
    }
}