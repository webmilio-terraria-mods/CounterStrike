using CounterStrike.Guns;
using CounterStrike.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Commands;

namespace CounterStrike.Commands.Ammo
{
    public sealed class FillAmmoCommand : CSDebugCommand
    {
        public const string CommandName = "cs_fillammo";


        public FillAmmoCommand() : base(CommandName, CommandType.Chat)
        {
        }


        protected override void ActionLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            if (!(player.HeldItem?.modItem is GunItem gun))
            {
                Main.NewText("You must be holding a gun to refill ammo!", Color.Yellow);
                return;
            }

            var csPlayer = CSPlayer.Get(player);
            
            if (!csPlayer.TryFillAmmo(gun.Definition))
                Main.NewText($"Couldn't buy ammo for this {gun.Definition.UnlocalizedName}.", Color.DarkRed);
            else
                Main.NewText("Ammo refilled!", Color.DarkGreen);
        }
    }
}