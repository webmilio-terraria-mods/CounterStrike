using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace CounterStrike.Players
{
    public sealed partial class CSPlayer : ModPlayer
    {
        #region Player Getters

        public static CSPlayer Get() => Get(Main.LocalPlayer);
        public static CSPlayer Get(ModPlayer modPlayer) => Get(modPlayer.player);
        public static CSPlayer Get(Player player) => player.GetModPlayer<CSPlayer>();

        #endregion


        public int ModifyMoney(int amount)
        {
            Money += amount;

            // TODO Add animation code here.

            return Money;
        }


        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            ModifyHitNPC(item, null, target, ref damage, ref knockback, ref crit);
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            ModifyHitNPC(null, proj, target, ref damage, ref knockback, ref crit);
        }

        public void ModifyHitNPC(Item item, Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            // Move this to a OnKilledNPC kind of thing.
            ModifyHitNPCKillFeed(null, proj, target, ref damage, ref knockback, ref crit);
        }


        public int Money
        {
            get;
            /*get => _money; Disabled since we don't really think other players need to know how much money a player has.
            set
            {
                if (value == _money)
                    return;

                int oldMoney = _money;
                _money = value;

                this.SendIfLocal(new PlayerMoneyChangedPacket(_money - oldMoney));
            }*/
            set;
        }
    }
}