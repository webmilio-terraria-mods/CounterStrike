using CounterStrike.NPCs;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Commands;

namespace CounterStrike.Commands.Debug
{
    public class ReloadCSNPCHitBoxes : StandardCommand
    {
        public ReloadCSNPCHitBoxes() : base("cs_reloadhitboxes", CommandType.Chat)
        {
        }


        protected override void ActionLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            Main.NewText("Unloading CS NPC HitBoxes...");
            CSNPCHitBoxesLoader.Instance.Unload();

            Main.NewText("Loading CS NPC HitBoxes...");
            CSNPCHitBoxesLoader.Instance.TryLoad();

            Main.NewText("Reload complete.");
        }
    }
}