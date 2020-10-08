using CounterStrike.Guns;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Commands;

namespace CounterStrike.Commands.Debug
{
    public class ReloadGunDefinitions : CSDebugCommand
    {
        public ReloadGunDefinitions() : base("cs_reloadgundefs", CommandType.Chat)
        {
        }


        protected override void ActionLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            Main.NewText("Unloading CS Gun Definitions...");
            GunDefinitions.Instance.Unload();

            Main.NewText("Loading CS Gun Definitions...");
            GunDefinitions.Instance.TryLoad();

            Main.NewText("Reload complete.");
        }
    }
}