using Microsoft.Xna.Framework;

namespace CounterStrike.Guns.Pistols.Deagle
{
    public class Deagle : GunItem
    {
        public Deagle() : base("Deagle", 
            "As expensive as it is powerful, the Desert Eagle is an iconic\n" +
            "pistol that is difficult to master but surprisingly accurate at long range.",
            42, 27, GunDefinitions.Instance.GetGeneric<DeagleDefinition>())
        {
        }


        public override Vector2? HoldoutOffset() => new Vector2(-5, -3);
    }
}