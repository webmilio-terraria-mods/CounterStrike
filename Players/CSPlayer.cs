using CounterStrike.Guns;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CounterStrike.Players
{
    public sealed partial class CSPlayer : ModPlayer
    {
        private Item _previouslyHeldItem;
        public const int MaxMoney = 16000;

        #region Player Getters

        public static CSPlayer Get() => Get(Main.LocalPlayer);
        public static CSPlayer Get(int whoAmI) => Get(Main.player[whoAmI]);
        public static CSPlayer Get(ModPlayer modPlayer) => Get(modPlayer.player);
        public static CSPlayer Get(Player player) => player.GetModPlayer<CSPlayer>();

        #endregion

        private const float ACCURACY_PER_TICK = 2f / Constants.TICKS_PER_SECOND;
        private float _accuracyFactor;


        /// <summary>Changes the player's money by the given amount. Triggers animation on local client.</summary>
        /// <param name="amount">The difference to add.</param>
        /// <returns>The new amount.</returns>
        public int ModifyMoney(int amount)
        {
            var newMoney = Money + amount;

            if (newMoney > MaxMoney)
                newMoney = MaxMoney;

            if (newMoney < 0)
                newMoney = 0;

            Money = newMoney;
            // TODO Add animation code here.

            return Money;
        }


        #region Hooks

        public override void Initialize()
        {
            InitializeGuns();
            InitializeAmmo();
        }


        public override void Load(TagCompound tag)
        {
            Money = tag.GetInt(nameof(Money));

            LoadAmmo(tag);
            LoadGuns(tag);
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


        public override void PostItemCheck()
        {
            if (_previouslyHeldItem != player.HeldItem)
                GunMounted = false;

            _previouslyHeldItem = player.HeldItem;
        }


        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            LeftClick = triggersSet.MouseLeft;

            if (CSMod.Instance.OpenBuyMenu.JustPressed)
                CSMod.Instance.BuyLayer.BuyUIState.Visible = !CSMod.Instance.BuyLayer.BuyUIState.Visible;
        }


        public override void PreUpdate()
        {
            GunItem gunItem = null;

            if (player.HeldItem != null && player.HeldItem.modItem is GunItem csGun)
                gunItem = csGun;

            if (gunItem == null || gunItem.Definition.GetAccuracyChangePerShot(this) < 0)
            {
                AccuracyFactor += ACCURACY_PER_TICK;

                if (AccuracyFactor >= 1)
                    AccuracyFactor = 1;
            }
            else if (gunItem.Definition.GetAccuracyChangePerShot(this) > 0 && !LeftClick)
                AccuracyFactor = 0;
        }

        public override void PreUpdateMovement()
        {

        }


        public override void ResetEffects()
        {
            if (Main.FrameSkipMode > 0)
                CSMod.Instance.KillFeedLayer?.KillFeedUIState?.KillFeedElement?.UpdateFeed(Main._drawInterfaceGameTime);

            
            ResetEffectsAmmo();
        }


        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound()
            {
                { nameof(Money), Money }
            };

            SaveAmmo(tag);
            SaveGuns(tag);

            return tag;
        }

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
        } = 800;

        public float AccuracyFactor
        {
            get => _accuracyFactor;
            set
            {
                if (value < 0)
                    _accuracyFactor = 0;
                else if (value > 1)
                    _accuracyFactor = 1;
                else
                    _accuracyFactor = value;
            }
        }


        public bool LeftClick { get; private set; }
    }
}