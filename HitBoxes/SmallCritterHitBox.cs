using Microsoft.Xna.Framework;
using Terraria.ID;

namespace CounterStrike.HitBoxes
{
    public abstract class SmallCritterHitBox : HitBox
    {
        protected SmallCritterHitBox(params int[] npcIDs) : base(npcIDs)
        {
        }


        public override bool IsHead(Vector2 position) => true;
        public override bool IsChestArms(Vector2 position) => true;
        public override bool IsAbdomenPelvis(Vector2 position) => true;
        public override bool IsLegs(Vector2 position) => true;
    }

    public class BirdHitBox : SmallCritterHitBox
    {
        public BirdHitBox() : base(NPCID.Bird, NPCID.BirdBlue, NPCID.BirdRed, NPCID.GoldBird)
        {
        }
    }
}