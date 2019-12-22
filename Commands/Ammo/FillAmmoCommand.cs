using Terraria.ModLoader;
using WebmilioCommons.Commands;

namespace CounterStrike.Commands.Ammo
{
    public sealed class FillAmmoCommand : StandardCommand
    {
        public const string COMMAND = "cs_fillammo";


        public FillAmmoCommand() : base(COMMAND, CommandType.Chat)
        {
        }
    }
}