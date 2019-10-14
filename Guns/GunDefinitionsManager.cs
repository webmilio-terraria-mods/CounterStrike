using WebmilioCommons.Managers;

namespace CounterStrike.Guns
{
    public sealed class GunDefinitionsManager : SingletonManager<GunDefinitionsManager, GunDefinition>
    {
        public override void DefaultInitialize()
        {
            //Glock18 = Add(new GunDefinition())
            Glock18 = default;

            base.DefaultInitialize();
        }


        public GunDefinition Glock18 { get; private set; }
    }
}