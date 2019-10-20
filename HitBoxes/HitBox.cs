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


        public abstract bool IsHead(NPC npc, Vector2 position);

        public abstract bool IsChestArms(NPC npc, Vector2 position);

        public abstract bool IsAbdomenPelvis(NPC npc, Vector2 position);

        public abstract bool IsLegs(NPC npc, Vector2 position);


        public int[] NPCIDs { get; }
    }
}