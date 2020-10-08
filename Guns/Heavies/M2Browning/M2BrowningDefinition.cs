using CounterStrike.Damage;
using CounterStrike.Players;

namespace CounterStrike.Guns.Heavies.M2Browning
{
    public sealed class M2BrowningDefinition : GunDefinition
    {
        public const int ConstDamage = 50;


        public M2BrowningDefinition() : base("m2browning", HeavyCategory.Instance, 8000, 2f, 200, 1, new FiringMode[] { FiringMode.Automatic },
            800, 0.20f, 150, ConstDamage, 0.70f, -0.33f, 1f, 400, 
            new DamageProperties(4, 1, 1, 0.8f), canBeMounted: true)
        {
        }


        public override float GetAccuracy(CSPlayer csPlayer) => csPlayer.GunMounted ? 0.90f : BaseAccuracy;

        public override float GetAccuracyChangePerShot(CSPlayer csPlayer) => BaseAccuracyChangePerShot;
    }
}