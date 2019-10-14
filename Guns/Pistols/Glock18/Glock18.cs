namespace CounterStrike.Guns.Pistols.Glock18
{
    public sealed class Glock18 : CSGun
    {
        public Glock18() : base("Glock-18", 
            "The Glock 18 is a serviceable first-round pistol that works best against\n" +
            "unarmored opponents and is capable of firing three-round bursts.",
            40, 28, GunDefinitionsManager.Instance.Glock18)
        {
        }
    }
}