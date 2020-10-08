using CounterStrike.Damage;

namespace CounterStrike.Guns.Heavies.Negev
{
    public class NegevDefinition : GunDefinition
    {
        public const int ConstDamage = 35;


        public NegevDefinition() : base("negev", HeavyCategory.Instance, 1700, 1.66f, 150, 1, new FiringMode[] { FiringMode.Automatic },
            800, 150f / 250, 300, ConstDamage, 0.76f, 0.0485f, 0.71f, 200,
            new DamageProperties(ConstDamage, 140, 35, 43, 26))
        {
        }
    }
}