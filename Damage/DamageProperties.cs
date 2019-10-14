namespace CounterStrike.Damage
{
    public struct DamageProperties
    {
        public readonly DamagePair head, chestArm, abdomenPelvis, legs;


        public DamageProperties(DamagePair head, DamagePair chestArm, DamagePair abdomenPelvis, DamagePair legs)
        {
            this.head = head;
            this.chestArm = chestArm;
            this.abdomenPelvis = abdomenPelvis;
            this.legs = legs;
        }

        public DamageProperties(int unarmoredHead, int armoredHead, int unarmoredChestArms, int armoredChestArms, int unarmoredAbdomenPelvis, int armoredAbdomenPelvis, int unarmoredLegs, int armoredLegs)
            : this(new DamagePair(unarmoredHead, armoredHead), new DamagePair(unarmoredChestArms, armoredChestArms), new DamagePair(unarmoredAbdomenPelvis, armoredAbdomenPelvis), new DamagePair(unarmoredLegs, armoredLegs))
        {
        }
    }
}