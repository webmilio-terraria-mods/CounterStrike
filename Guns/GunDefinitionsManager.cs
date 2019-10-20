using CounterStrike.Guns.Pistols.Deagle;
using CounterStrike.Guns.Pistols.Glock18;
using CounterStrike.Guns.Rifles.AWP;
using CounterStrike.Guns.Rifles.M4;
using WebmilioCommons.Managers;

namespace CounterStrike.Guns
{
    public sealed class GunDefinitionsManager : SingletonManager<GunDefinitionsManager, GunDefinition>
    {
        public override void DefaultInitialize()
        {
            #region Pistons

            Glock18 = Add<Glock18Definition>();
            Deagle = Add<DeagleDefinition>();

            #endregion


            #region Rifles

            M4A1S = Add<M4A1SDefinition>();

            AWP = Add<AWPDefinition>();

            #endregion

            base.DefaultInitialize();
        }


        #region Pistols

        public Glock18Definition Glock18 { get; private set; }
        
        public DeagleDefinition Deagle { get; private set; }

        #endregion


        #region Rifles

        public M4A1SDefinition M4A1S { get; private set; }

        public AWPDefinition AWP { get; private set; }

        #endregion
    }
}