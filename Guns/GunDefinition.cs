using CounterStrike.Damage;
using CounterStrike.Guns.Categories;
using CounterStrike.Players;
using WebmilioCommons.Managers;

namespace CounterStrike.Guns
{
    public abstract class GunDefinition : IHasUnlocalizedName
    {
        protected GunDefinition(string unlocalizedName, GunCategory category, int price, float bulletCost, int magazineSize, int startingMagazineCount, FiringMode[] firingModes, int rpm, float baseMoveSpeedModifier, int killAward,
            int damage, float baseAccuracy, float baseAccuracyChangePerShot, float armorPenetration, int penetrationPower, DamageProperties damageProperties, bool canBeMounted = false)
        {
            UnlocalizedName = unlocalizedName;
            
            Category = category;
            Category.Add(this);

            Price = price;

            BulletCost = bulletCost;
            MagazineSize = magazineSize;
            StartingMagazineCount = startingMagazineCount;

            FiringModes = firingModes;

            RPM = rpm;

            BaseMoveSpeedModifier = baseMoveSpeedModifier;

            KillAward = killAward;

            Damage = damage;

            BaseAccuracy = baseAccuracy;
            BaseAccuracyChangePerShot = baseAccuracyChangePerShot;

            ArmorPenetration = armorPenetration;
            PenetrationPower = penetrationPower;

            DamageProperties = damageProperties;

            CanBeMounted = canBeMounted;
        }


        public bool IsAutomatic()
        {
            for (int i = 0; i < FiringModes.Length; i++)
                if (FiringModes[i] == FiringMode.Automatic)
                    return true;

            return false;
        }


        public virtual float GetAccuracy(CSPlayer csPlayer) => BaseAccuracy;

        public virtual float GetAccuracyChangePerShot(CSPlayer csPlayer) => BaseAccuracyChangePerShot;


        public virtual float GetMoveSpeedModifier(CSPlayer csPlayer) => BaseMoveSpeedModifier;


        public string UnlocalizedName { get; }
        public GunCategory Category { get; }

        public virtual GunItem GunItem { get; internal set; }

        public int Price { get; }

        public float BulletCost { get; }
        public int MagazineSize { get; }
        public int StartingMagazineCount { get; }

        public FiringMode[] FiringModes { get; }

        /// <summary>Rounds per minute</summary>
        public int RPM { get; }

        public float BaseMoveSpeedModifier { get; }

        public int KillAward { get; }

        public int Damage { get; }

        public float BaseAccuracy { get; }
        public float BaseAccuracyChangePerShot { get; }

        public float ArmorPenetration { get; }
        public int PenetrationPower { get; }

        public DamageProperties DamageProperties { get; }

        public bool CanBeMounted { get; }
    }
}