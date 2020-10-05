using CounterStrike.Damage;

namespace CounterStrike.Guns.Rifles.M4
{
    public class M4A1SDefinition : GunDefinition
    {
        public const int ConstDamage = 33;


        public M4A1SDefinition() : base("m4a1s", 3100, 3.2f, 25, 2, new FiringMode[] { FiringMode.Automatic },
            600, 0.9f, 300, ConstDamage, 0.73f, -0.25f, 0.7f, 200,
            new DamageProperties(ConstDamage, 131, 32, 41, 24))
        {
        }
    }
}