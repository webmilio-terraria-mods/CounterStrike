using Microsoft.Xna.Framework;
using Terraria.ID;

namespace CounterStrike.Guns.Heavies.M2Browning
{
    public sealed class M2Browning : GunItem
    {
        public M2Browning() : base("M2 Browning",
            "A large autocannon usually used mounted." +
            "\nShreds through waves of enemies with ease." + 
            "\nCan be mounted if on the ground.",
            94, 18, GunDefinitions.Instance.GetGeneric<M2BrowningDefinition>(),
            rarity: ItemRarityID.Red, shootProjectile: ProjectileID.BulletHighVelocity, shootSpeed: 20f)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.UseSound = SoundID.Item38;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
    }
}