using CounterStrike.Damage;

namespace CounterStrike.Guns.Rifles.AK47
{
    public class AK47Definition : GunDefinition
    {
        public const int
            ConstMagazineSize = 30,
            ConstMagazinePrice = 80,
            ConstDamage = 36;


        public AK47Definition() : base("ak47", 2700, (float) ConstMagazinePrice / ConstMagazineSize, ConstMagazineSize, 2, new FiringMode[] {FiringMode.Automatic},
            600, 0.86f, 300, ConstDamage, 0.85f, -0.31f, 0.775f, 200,
            new DamageProperties(ConstDamage, 143, 35, 44, 26))
        {
        }
    }
}