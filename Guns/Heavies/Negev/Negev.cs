using Microsoft.Xna.Framework;

namespace CounterStrike.Guns.Heavies.Negev
{
    public class Negev : GunItem
    {
        public Negev() : base("Negev",
            "The Negev is a beast that can keep the enemy at bay with its pin-point\n" +
            "supressive fire, provided you have the luxury of time to gain control over it.",
            88, 28, GunDefinitions.Instance.GetGeneric<NegevDefinition>())
        {
        }


        public override Vector2? HoldoutOffset() => new Vector2(-20, 5);
    }
}