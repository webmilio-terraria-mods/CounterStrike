namespace CounterStrike.Guns.Pistols.Glock18
{
    public class Glock18 : CSGun
    {
        public Glock18() : base("Glock-18", 
            "The Glock 18 is a serviceable first-round pistol that works best against\n" +
            "unarmored opponents and is capable of firing three-round bursts (not yet lmao).",
            30, 22, GunDefinitionLoader.Instance.GetGeneric<Glock18Definition>())
        {
        }


        //public override Vector2? HoldoutOffset() => new Vector2(-5, 5);
    }
}