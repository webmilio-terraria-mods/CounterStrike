using Microsoft.Xna.Framework;

namespace CounterStrike.Guns.Rifles.M4
{
    public class M4A4 : CSGun
    {
        public M4A4() : base("M4A4",
            "More accurate but less damaging than its AK-47 counterpart,\n" +
            "the M4A4 is the full-auto assault rifle of choice for CTs.",
            68, 28, GunDefinitionsManager.Instance.M4A4)
        {
        }


        public override Vector2? HoldoutOffset() => new Vector2(-17, 5);
    }
}