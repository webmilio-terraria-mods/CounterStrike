using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace CounterStrike.HitBoxes
{
    public class CursedSkullsHitBox : HitBox
    {
        public CursedSkullsHitBox() : base(NPCID.CursedSkull, NPCID.GiantCursedSkull)
        {
        }


        public override bool IsHead(NPC npc, Vector2 position) => false;

        public override bool IsChestArms(NPC npc, Vector2 position) => true;

        public override bool IsAbdomenPelvis(NPC npc, Vector2 position) => false;

        public override bool IsLegs(NPC npc, Vector2 position) => false;
    }
}