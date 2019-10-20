using CounterStrike.Guns;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
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


        private float _accuracyFactor;


        /// <summary>Changes the player's money by the given amount. Triggers animation on local client.</summary>
        /// <param name="amount">The difference to add.</param>
        /// <returns>The new amount.</returns>
        public int ModifyMoney(int amount)
        {
            Money += amount;
            Main.NewText($"Gained {amount}$");

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


        #region Hooks

        public override void Initialize()
        {
            InitializeGuns();
        }

        public override void ResetEffects()
        {
            if (AccuracyFactor < 1)
            {
                AccuracyFactor += 0.0175f;

                if (AccuracyFactor >= 1)
                    AccuracyFactor = 1;
            }
        }


        public override void Load(TagCompound tag)
        {
            Money = tag.GetInt(nameof(Money));
        }

        public override TagCompound Save() =>
            new TagCompound()
            {
                { nameof(Money), Money }
            };

        #endregion


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

        public float AccuracyFactor
        {
            get => _accuracyFactor;
            set
            {
                if (value < 0)
                    _accuracyFactor = 0;
                else
                    _accuracyFactor = value;
            }
        }
    }
}