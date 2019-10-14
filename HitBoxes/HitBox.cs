using Microsoft.Xna.Framework;

namespace CounterStrike.HitBoxes
{
    public abstract class HitBox
    {
        protected HitBox(int[] npcIDs)
        {
            NPCIDs = npcIDs;
        }


        public abstract bool IsHead(Vector2 position);

        public abstract bool IsChestArms(Vector2 position);

        public abstract bool IsAbdomenPelvis(Vector2 position);

        public abstract bool IsLegs(Vector2 position);


        public int[] NPCIDs { get; }
    }
}