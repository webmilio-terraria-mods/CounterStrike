using System;
using CounterStrike.Items;
using CounterStrike.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace CounterStrike.Guns
{
    public abstract class CSGun : CSItem
    {
        protected CSGun(string displayName, string tooltip, int width, int height, GunDefinition definition, int rarity = ItemRarityID.White) : 
            base(displayName, tooltip, width, height, value: 0, rarity: rarity, defense: 0)
        {
            Definition = definition;
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
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 16f;
        }


        public override bool CanUseItem(Player player)
        {
            CSPlayer csPlayer = CSPlayer.Get(player);

            return csPlayer.HasAmmo(Definition) && !csPlayer.Reloading;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            CSPlayer csPlayer = CSPlayer.Get(player);

            Vector2 unaccurateSpeed = new Vector2(speedX, speedY).RotatedByRandom(
                (1 - csPlayer.AccuracyFactor) * MathHelper.ToRadians((1 - Definition.Accuracy) * Constants.MAX_SPREAD));

            speedX = unaccurateSpeed.X;
            speedY = unaccurateSpeed.Y;

            csPlayer.AccuracyFactor += Definition.AccuracyChangePerShot;

            return true;
        }


        public GunDefinition Definition { get; }
    }
}