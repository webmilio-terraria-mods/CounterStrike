namespace CounterStrike.Damage
{
    public struct DamageProperties
    {
        public readonly float headMultiplier, chestArmsMultiplier, abdomenPelvisMultiplier, legsMultiplier;


        public DamageProperties(float headMultiplier, float chestArmsMultiplier, float abdomenPelvisMultiplier, float legsMultiplier)
        {
            this.headMultiplier = headMultiplier;
            this.chestArmsMultiplier = chestArmsMultiplier;
            this.abdomenPelvisMultiplier = abdomenPelvisMultiplier;
            this.legsMultiplier = legsMultiplier;
        }

        public DamageProperties(int damage, int head, int chestArms, int abdomenPelvis, int legs)
        {
            float fDamage = (float) damage + 1;

            this.headMultiplier = head / fDamage;
            this.chestArmsMultiplier = chestArms / fDamage;
            this.abdomenPelvisMultiplier = abdomenPelvis / fDamage;
            this.legsMultiplier = legs / fDamage;
        }
    }
}