using CounterStrike.Damage;

namespace CounterStrike.Guns.Rifles.M4
{
    public class M4A4Definition : GunDefinition
    {
        public const int ConstDamage = 33;


        public M4A4Definition() : base("m4a4", RifleCategory.Instance, 3100, 2.66f, 30, 2, new FiringMode[] {  FiringMode.Automatic }, 
            666, 225f / 250, 300, ConstDamage, 0.76f, -0.3f, 0.7f, 200,
            new DamageProperties(ConstDamage, 131, 32, 40, 24))
        {
        }
    }
}