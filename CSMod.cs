using System.IO;
using Terraria.ModLoader;
using WebmilioCommons.Networking;

namespace CounterStrike
{
	public class CSMod : Mod
	{
		public CSMod()
        {
            Instance = this;
        }


        public override void HandlePacket(BinaryReader reader, int whoAmI) => NetworkPacketLoader.Instance.HandlePacket(reader, whoAmI);


        public static CSMod Instance { get; private set; }
	}
}