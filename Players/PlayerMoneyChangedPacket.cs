using WebmilioCommons.Networking.Packets;

namespace CounterStrike.Players
{
    public class PlayerMoneyChangedPacket : ModPlayerNetworkPacket<CSPlayer>
    {
        public PlayerMoneyChangedPacket() { }

        public PlayerMoneyChangedPacket(int amount)
        {
            Amount = amount;
        }


        public int Amount { get; set; }

        public int Money
        {
            get => ModPlayer.Money;
            set => ModPlayer.Money = value;
        }
    }
}