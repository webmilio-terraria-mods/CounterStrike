using Microsoft.Xna.Framework;
using Terraria;

namespace CounterStrike.HitBoxes.Humanoid
{
    public abstract class SmallHumanoidHitBox : HitBox
    {
        protected SmallHumanoidHitBox(params int[] npcIDs) : base(npcIDs)
        {
        }


        public override bool IsHead(NPC npc, Vector2 position)
        {
            return false;
        }

        public override bool IsChestArms(NPC npc, Vector2 position)
        {
            return false;
        }

        public override bool IsAbdomenPelvis(NPC npc, Vector2 position)
        {
            return false;
        }

        public override bool IsLegs(NPC npc, Vector2 position)
        {
            return false;
        }
    }
}