using Terraria;
using Terraria.ModLoader;

namespace CounterStrike.Commands.Debug
{
    public class ShowHitBoxesCommand : CSDebugCommand
    {
        public ShowHitBoxesCommand() : base("cs_hitboxes", CommandType.Chat)
        {
        }


        protected override void ActionLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            if (!bool.TryParse(args[0], out bool show))
                return;

            ShowHitBoxes = show;
        }


        public static bool ShowHitBoxes { get; private set; }
    }
}