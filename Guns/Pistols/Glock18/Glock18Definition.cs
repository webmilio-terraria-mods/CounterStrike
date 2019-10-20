using CounterStrike.Damage;

namespace CounterStrike.Guns.Pistols.Glock18
{
    public sealed class Glock18Definition : GunDefinition
    {
        public const int DAMAGE = 30;


        public Glock18Definition() : base("glock18", 500, 50, 18, new FiringMode[] { FiringMode.SemiAutomatic },
            400, 240f / 250, 300, DAMAGE, 0.84f, 0.33f, 0.9015f, 100,
            new DamageProperties(DAMAGE, 118, 29, 37, 22))
        {
        }
    }
}