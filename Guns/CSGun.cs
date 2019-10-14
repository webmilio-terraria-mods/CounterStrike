using System;
using CounterStrike.Items;
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
            item.useTime = (int)Math.Ceiling(60 * ((float) Definition.RPM / (60 * Constants.TICKS_PER_SECOND)));
            item.useAnimation = item.useTime;

            item.damage = Definition.Damage;
            item.autoReuse = Definition.IsAutomatic();

            item.UseSound = SoundID.Item11;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 16f;
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 unaccurateSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians((1 - Definition.Accuracy) * Constants.MAX_SPREAD));

            speedX = unaccurateSpeed.X;
            speedY = unaccurateSpeed.Y;

            return true;
        }


        public GunDefinition Definition { get; }
    }
}