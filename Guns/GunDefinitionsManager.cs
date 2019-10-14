using CounterStrike.Guns.Pistols.Glock18;
using WebmilioCommons.Managers;

namespace CounterStrike.Guns
{
    public sealed class GunDefinitionsManager : SingletonManager<GunDefinitionsManager, GunDefinition>
    {
        public override void DefaultInitialize()
        {
            //Glock18 = Add(new GunDefinition())
            Glock18 = Add<Glock18Definition>();

            base.DefaultInitialize();
        }


        public GunDefinition Glock18 { get; private set; }
    }
}