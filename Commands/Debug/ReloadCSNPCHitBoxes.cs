using CounterStrike.NPCs;
using Microsoft.Xna.Framework;
using SourceEngineConsole.Commands;
using Terraria;
using Terraria.ModLoader;

namespace CounterStrike.Commands.Debug
{
    public class ReloadCSNPCHitBoxes : SourceEngineCommand
    {
        public ReloadCSNPCHitBoxes() : base("cs_reloadhitboxes", CommandType.Chat)
        {
        }


        protected override void RunLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            Main.NewText("Unloading CS NPC HitBoxes...");
            CSNPCHitBoxes.Instance.Unload();

            Main.NewText("Loading CS NPC HitBoxes...");
            CSNPCHitBoxes.Instance.Load();

            Main.NewText("Reload complete.");
        }
    }
}