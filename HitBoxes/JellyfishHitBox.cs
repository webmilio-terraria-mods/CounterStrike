using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace CounterStrike.HitBoxes
{
    public class JellyfishHitBox : HitBox
    {
        public JellyfishHitBox() : base(NPCID.BlueJellyfish, NPCID.BloodJelly, NPCID.GreenJellyfish, NPCID.PinkJellyfish)
        {
        }


        public override bool IsHead(NPC npc, Vector2 position) => false;

        public override bool IsChestArms(NPC npc, Vector2 position) => true;

        public override bool IsAbdomenPelvis(NPC npc, Vector2 position) => false;

        public override bool IsLegs(NPC npc, Vector2 position) => false;
    }
}