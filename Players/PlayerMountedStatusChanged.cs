using WebmilioCommons.Networking.Packets;

namespace CounterStrike.Players
{
    public class PlayerMountedStatusChanged : ModPlayerNetworkPacket<CSPlayer>
    {
        public bool GunMounted
        {
            get => ModPlayer.GunMounted;
            set
            {
                if (value)
                    ModPlayer.MountGun();
                else
                    ModPlayer.DismountGun();
            }
        }
    }
}