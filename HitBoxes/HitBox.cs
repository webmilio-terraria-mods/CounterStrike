using Microsoft.Xna.Framework;
using Terraria;

namespace CounterStrike.HitBoxes
{
    public abstract class HitBox
    {
        protected HitBox(params int[] npcIDs)
        {
            NPCIDs = npcIDs;
        }


        public abstract bool IsHead(Vector2 position, NPC npc, Projectile projectile);

        public abstract bool IsChestArms(Vector2 position, NPC npc, Projectile projectile);

        public abstract bool IsAbdomenPelvis(Vector2 position, NPC npc, Projectile projectile);

        public abstract bool IsLegs(Vector2 position, NPC npc, Projectile projectile);


        public int[] NPCIDs { get; }
    }
}