using System.Collections.Generic;
using System.IO;
using CounterStrike.Guns;
using CounterStrike.Projectiles;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Networking;

namespace CounterStrike
{
	public sealed partial class CSMod : Mod
	{
		public CSMod()
        {
            Instance = this;
        }


        public override void Load()
        {
            CSGlobalProjectile.gunDefinitionPerProjectile = new Dictionary<Projectile, GunDefinition>();


            if (!Main.dedServ)
            {
                LoadClient();
            }
        }

        public override void Unload()
        {
            CSGlobalProjectile.gunDefinitionPerProjectile = null;


            GunDefinitionsManager.Instance.Unload();
        }


        public override void HandlePacket(BinaryReader reader, int whoAmI) => NetworkPacketLoader.Instance.HandlePacket(reader, whoAmI);


        public static CSMod Instance { get; private set; }
	}
}