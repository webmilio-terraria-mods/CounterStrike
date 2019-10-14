using CounterStrike.Damage;

namespace CounterStrike.Guns.Pistols.Glock18
{
    public sealed class Glock18Definition : GunDefinition
    {
        public Glock18Definition() : base("glock18", 500, 50, 18, new FiringMode[] { FiringMode.SemiAutomatic },
            400, 240f / 250, 300, 33, 0.84f, 13, 0.9015f, 100, 0.79f,
            new DamageProperties(30, 118, 29, 37, 22))
        {
        }
    }
}