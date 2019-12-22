using CounterStrike.Damage;

namespace CounterStrike.Guns.Heavy.Negev
{
    public class NegevDefinition : GunDefinition
    {
        public const int DAMAGE = 35;


        public NegevDefinition() : base("negev", 1700, 1.66f, 150, 1, new FiringMode[] { FiringMode.Automatic },
            800, 150f / 250, 300, DAMAGE, 0.76f, 0.0485f, 0.71f, 200,
            new DamageProperties(DAMAGE, 140, 35, 43, 26))
        {
        }
    }
}