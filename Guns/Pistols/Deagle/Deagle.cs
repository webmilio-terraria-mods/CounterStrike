using Microsoft.Xna.Framework;

namespace CounterStrike.Guns.Pistols.Deagle
{
    public class Deagle : CSGun
    {
        public Deagle() : base("Deagle", 
            "As expensive as it is powerful, the Desert Eagle is an iconic\n" +
            "pistol that is difficult to master but surprisingly accurate at long range.",
            42, 27, GunDefinitionsManager.Instance.Deagle)
        {
        }


        public override Vector2? HoldoutOffset() => new Vector2(-5, -3);
    }
}