using CounterStrike.Damage;
using WebmilioCommons.Managers;

namespace CounterStrike.Guns
{
    public class GunDefinition : IHasUnlocalizedName
    {
        public GunDefinition(string unlocalizedName, int price, int magazineCost, int clipSize, FiringMode[] firingModes, int rpm, float moveSpeedModifier, float killAwardMultiplier,
            int damage, int recoilRange, int accurateRange, float armorPenetration, int penetrationPower, float rangeModifier, DamageProperties damageProperties)
        {
            UnlocalizedName = unlocalizedName;

            Price = price;

            MagazineCost = magazineCost;
            ClipSize = clipSize;

            FiringModes = firingModes;

            RPM = rpm;

            MoveSpeedModifier = moveSpeedModifier;

            KillAwardMultiplier = killAwardMultiplier;

            Damage = damage;

            RecoilRange = recoilRange;

            AccurateRange = accurateRange;

            ArmorPenetration = armorPenetration;
            PenetrationPower = penetrationPower;

            RangeModifier = rangeModifier;

            DamageProperties = damageProperties;
        }


        public string UnlocalizedName { get; }

        public int Price { get; }

        public int MagazineCost { get; }
        public int ClipSize { get; }

        public FiringMode[] FiringModes { get; }

        /// <summary>Rounds per minute</summary>
        public int RPM { get; }

        public float MoveSpeedModifier { get; }

        public float KillAwardMultiplier { get; }

        public int Damage { get; }

        public int RecoilRange { get; }

        public int AccurateRange { get; }

        public float ArmorPenetration { get; }
        public int PenetrationPower { get; }

        public float RangeModifier { get; }

        public DamageProperties DamageProperties { get; }
    }
}