using CounterStrike.Damage;

namespace CounterStrike.Guns.Pistols.Deagle
{
    public class DeagleDefinition : GunDefinition
    {
        public const int DAMAGE = 63;


        public DeagleDefinition() : base("deagle", 700, 5.71f, 7, 2, new FiringMode[] { FiringMode.SemiAutomatic }, 
            267, 230f / 250, 300, DAMAGE, 0.12f, -0.8f, 0.932f, 200,
            new DamageProperties(DAMAGE, 249, 62, 77, 46))
        {
        }
    }
}