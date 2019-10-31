using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace CounterStrike.HitBoxes.Eyes
{
    public class DemonEyesHitBox : HitBox
    {
        public DemonEyesHitBox() : base(NPCID.DemonEye, NPCID.DemonEye2, NPCID.DemonEyeOwl, NPCID.DemonEyeSpaceship, NPCID.EyeofCthulhu)
        {
        }


        public override bool IsHead(NPC npc, Vector2 position)
        {
            Main.NewText(MathHelper.ToDegrees(npc.rotation));

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