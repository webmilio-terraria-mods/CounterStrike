using Microsoft.Xna.Framework;
using Terraria;

namespace CounterStrike.HitBoxes.Humanoid.Standard
{
    public abstract class StandardHumanoidHitBox : HitBox
    {
        protected StandardHumanoidHitBox(params int[] npcIDs) : base(npcIDs)
        {
        }


        public override bool IsHead(NPC npc, Vector2 position) => position.Y < 16f;

        public override bool IsChestArms(NPC npc, Vector2 position) => position.Y < 22f;

        public override bool IsAbdomenPelvis(NPC npc, Vector2 position) => position.Y < 25f;

        public override bool IsLegs(NPC npc, Vector2 position) => position.Y < 35f; // The hitbox isn't that big but this gives us a bit of room in case we calculated it wrong.
    }
}