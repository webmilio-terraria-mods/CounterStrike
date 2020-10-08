using System;
using System.Collections.Generic;
using CounterStrike.Items;
using CounterStrike.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CounterStrike.Guns
{
    public abstract class GunItem : CSItem
    {
        protected GunItem(string displayName, string tooltip, int width, int height, GunDefinition definition, int rarity = ItemRarityID.White, 
            int shootProjectile = ProjectileID.Bullet, float shootSpeed = 16f) : 
            base(displayName, tooltip, width, height, value: 0, rarity: rarity, defense: 0)
        {
            Definition = definition;

            ShootProjectile = shootProjectile;
            ShootSpeed = shootSpeed;
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.maxStack = 1;

            item.ranged = true;
            item.noMelee = true;

            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = (int)Math.Ceiling(Constants.TICKS_PER_SECOND / ((float) Definition.RPM / 60));
            item.useAnimation = item.useTime;

            item.damage = Definition.Damage;
            item.autoReuse = Definition.IsAutomatic();
            item.crit = 0;

            item.UseSound = SoundID.Item11;
            item.shoot = ShootProjectile;
            item.shootSpeed = ShootSpeed;
        }


        public override bool Autoload(ref string name)
        {
            Definition.GunItem = this;

            return base.Autoload(ref name);
        }


        public override bool AltFunctionUse(Player player) => Definition.CanBeMounted && player.velocity == Vector2.Zero;

        public override bool ConsumeAmmo(Player player) => false;

        public override bool CanUseItem(Player player)
        {
            CSPlayer csPlayer = CSPlayer.Get(player);

            if (player.altFunctionUse == ItemAlternativeFunctionID.ActivatedAndUsed)
            {
                
                if (Main.mouseRightRelease)
                {
                    csPlayer.ToggleMount();
                    CombatText.NewText(new Rectangle((int) player.Center.X, (int) player.Center.Y, 0, 0), Color.Red, csPlayer.GunMounted ? "Mounted" : "Dismounted");
                }

                return false;
            }

            return csPlayer.HasAmmo(Definition) && !csPlayer.Reloading;
        }


        public override void HoldItem(Player player)
        {
            CSPlayer csPlayer = CSPlayer.Get(player);

            if (Definition.CanBeMounted && csPlayer.GunMounted)
            {
                player.maxRunSpeed = 0;
                player.velocity = Vector2.Zero;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var player = CSPlayer.Get();

            tooltips.Add(new TooltipLine(mod, "cs_ammo_avail", $"{player.GetAmmo(Definition)} / {Definition.MagazineSize}, max of {player.GetMaxClips(Definition)} clips"));
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            CSPlayer csPlayer = CSPlayer.Get(player);

            Vector2 unaccurateSpeed = new Vector2(speedX, speedY).RotatedByRandom(
                (1 - csPlayer.AccuracyFactor) * MathHelper.ToRadians((1 - Definition.GetAccuracy(csPlayer)) * Constants.MAX_SPREAD));

            speedX = unaccurateSpeed.X;
            speedY = unaccurateSpeed.Y;

            csPlayer.AccuracyFactor += Definition.GetAccuracyChangePerShot(csPlayer);

            csPlayer.ConsumeAmmo(Definition, 1);

            return true;
        }


        public GunDefinition Definition { get; }

        public int ShootProjectile { get; }

        public float ShootSpeed { get; }
    }
}