using CounterStrike.Damage;

namespace CounterStrike.Guns.Rifles.M4
{
    public class M4A1SDefinition : GunDefinition
    {
        public const int DAMAGE = 33;


        public M4A1SDefinition() : base("m4a1s", 3100, 3.2f, 25, 2, new FiringMode[] { FiringMode.Automatic },
            600, 0.9f, 300, DAMAGE, 0.73f, -0.25f, 0.7f, 200,
            new DamageProperties(DAMAGE, 132, 32, 41, 24))
        {
        }
    }
}