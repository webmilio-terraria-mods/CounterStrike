using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace CounterStrike.HitBoxes.Humanoid.Standard
{
    public class PaladinHitBox : HitBox
    {
        public PaladinHitBox() : base(NPCID.Paladin)
        {
        }


        public override bool IsHead(NPC npc, Vector2 position) => position.Y < 20.5f;

        public override bool IsChestArms(NPC npc, Vector2 position) => 
            position.Y >= 20.5f && position.Y < 58f; // Since he's holding a shield, we treat his entire body as a "chest".

        public override bool IsAbdomenPelvis(NPC npc, Vector2 position) => false;

        public override bool IsLegs(NPC npc, Vector2 position) => false;
    }
}