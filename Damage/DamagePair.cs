namespace CounterStrike.Damage
{
    public struct DamagePair
    {
        public readonly int unarmored, armored;


        public DamagePair(int unarmored, int armored)
        {
            this.unarmored = unarmored;
            this.armored = armored;
        }
    }
}