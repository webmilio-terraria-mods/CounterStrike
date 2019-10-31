using CounterStrike.Damage;
using WebmilioCommons.Managers;

namespace CounterStrike.Guns
{
    public class GunDefinition : IHasUnlocalizedName
    {
        public GunDefinition(string unlocalizedName, int price, int magazineCost, int clipSize, FiringMode[] firingModes, int rpm, float moveSpeedModifier, int killAward,
            int damage, float accuracy, float accuracyChangePerShot, float armorPenetration, int penetrationPower, DamageProperties damageProperties)
        {
            UnlocalizedName = unlocalizedName;

            Price = price;

            MagazineCost = magazineCost;
            ClipSize = clipSize;

            FiringModes = firingModes;

            RPM = rpm;

            MoveSpeedModifier = moveSpeedModifier;

            KillAward = killAward;

            Damage = damage;

            Accuracy = accuracy;
            AccuracyChangePerShot = accuracyChangePerShot;

            ArmorPenetration = armorPenetration;
            PenetrationPower = penetrationPower;

            DamageProperties = damageProperties;
        }


        public bool IsAutomatic()
        {
            for (int i = 0; i < FiringModes.Length; i++)
                if (FiringModes[i] == FiringMode.Automatic)
                    return true;

            return false;
        }


        public string UnlocalizedName { get; }

        public int Price { get; }

        public int MagazineCost { get; }
        public int ClipSize { get; }

        public FiringMode[] FiringModes { get; }

        /// <summary>Rounds per minute</summary>
        public int RPM { get; }

        public float MoveSpeedModifier { get; }

        public int KillAward { get; }

        public int Damage { get; }

        public float Accuracy { get; }
        public float AccuracyChangePerShot { get; }

        public float ArmorPenetration { get; }
        public int PenetrationPower { get; }

        public DamageProperties DamageProperties { get; }
    }
}