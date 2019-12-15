using SourceEngineConsole.Commands;
using Terraria;
using Terraria.ModLoader;

namespace CounterStrike.Commands.Debug
{
    public class ShowRotationLineCommand : SourceEngineCommand
    {
        public ShowRotationLineCommand() : base("cs_showrotationline", CommandType.Chat)
        {
        }


        protected override void RunLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            if (args.Length == 0)
            {
                Main.NewText("Rotation Lines: " + (ShowRotationLine ? "" : " not") + " visible");
                return;
            }

            if (!bool.TryParse(args[0], out bool show))
                return;

            ShowRotationLine = show;
        }


        public static bool ShowRotationLine { get; private set; }
    }
}