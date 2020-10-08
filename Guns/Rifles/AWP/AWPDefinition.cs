using CounterStrike.Damage;

namespace CounterStrike.Guns.Rifles.AWP
{
    public class AWPDefinition : GunDefinition
    {
        private const int ConstDamage = 115;


        public AWPDefinition() : base("awp", RifleCategory.Instance, 4750, 12.5f, 10, 1, new FiringMode[] { FiringMode.BoltAction }, 
            41, 200f / 250, 100, ConstDamage, 0.03f, -1f, 0.975f, 250,
            new DamageProperties(ConstDamage, 459, 115, 143, 85)
            /* new DamageProperties(DAMAGE, 459, 115, 143, 85) */)
        {
        }
    }
}