using CounterStrike.Damage;

namespace CounterStrike.Guns.Rifles.M4
{
    public class M4A4Definition : GunDefinition
    {
        public const int DAMAGE = 33;


        public M4A4Definition() : base("m4a4", 3100, 80, 30, new FiringMode[] {  FiringMode.Automatic }, 
            666, 225f / 250, 300, DAMAGE, 0.76f, -0.3f, 0.7f, 200,
            new DamageProperties(DAMAGE, 131, 32, 40, 24))
        {
        }
    }
}