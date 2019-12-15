using Microsoft.Xna.Framework;
using Terraria;

namespace CounterStrike.HitBoxes.Humanoid
{
    public abstract class SmallHumanoidHitBox : HitBox
    {
        protected SmallHumanoidHitBox(params int[] npcIDs) : base(npcIDs)
        {
        }


        public override bool IsHead(Vector2 position, NPC npc, Projectile projectile)
        {
            return false;
        }

        public override bool IsChestArms(Vector2 position, NPC npc, Projectile projectile)
        {
            return false;
        }

        public override bool IsAbdomenPelvis(Vector2 position, NPC npc, Projectile projectile)
        {
            return false;
        }

        public override bool IsLegs(Vector2 position, NPC npc, Projectile projectile)
        {
            return false;
        }
    }
}