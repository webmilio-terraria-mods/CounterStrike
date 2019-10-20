using CounterStrike.Damage;

namespace CounterStrike.Guns.Rifles.AWP
{
    public class AWPDefinition : GunDefinition
    {
        private const int DAMAGE = 115;


        public AWPDefinition() : base("awp", 4750, 125, 10, new FiringMode[] { FiringMode.BoltAction }, 
            41, 200f / 250, 100, DAMAGE, 0.03f, 1f, 0.975f, 250,
            new DamageProperties(DAMAGE, 750, 115, 143, 85)
            /* new DamageProperties(DAMAGE, 459, 115, 143, 85) */)
        {
        }
    }
}