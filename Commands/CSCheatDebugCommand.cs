using Terraria.ModLoader;

namespace CounterStrike.Commands
{
    public abstract class CSCheatDebugCommand : CSDebugCommand
    {
        protected CSCheatDebugCommand(string command, CommandType type) : base(command, type)
        {
        }
    }
}