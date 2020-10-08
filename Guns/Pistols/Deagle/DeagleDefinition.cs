using CounterStrike.Damage;

namespace CounterStrike.Guns.Pistols.Deagle
{
    public class DeagleDefinition : GunDefinition
    {
        public const int ConstDamage = 63;


        public DeagleDefinition() : base("deagle", PistolCategory.Instance, 700, 5.71f, 7, 2, new FiringMode[] { FiringMode.SemiAutomatic }, 
            267, 230f / 250, 300, ConstDamage, 0.12f, -0.8f, 0.932f, 200,
            new DamageProperties(ConstDamage, 249, 62, 77, 46))
        {
        }
    }
}