using CounterStrike.Damage;

namespace CounterStrike.Guns.Pistols.Glock18
{
    public sealed class Glock18Definition : GunDefinition
    {
        public const int BaseDamage = 30;


        public Glock18Definition() : base("glock18", PistolCategory.Instance, 500, 2.77f, 18, 3, new FiringMode[] { FiringMode.SemiAutomatic },
            400, 240f / 250, 300, BaseDamage, 0.84f, -0.33f, 0.9015f, 100,
            new DamageProperties(30, 118, 29, 37, 22))
        {
        }
    }
}