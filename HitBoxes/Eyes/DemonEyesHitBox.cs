using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using WebmilioCommons.Extensions;

namespace CounterStrike.HitBoxes.Eyes
{
    public class DemonEyesHitBox : HitBox
    {
        public DemonEyesHitBox() : base(
            NPCID.DemonEye, NPCID.DemonEye2, NPCID.DemonEyeOwl,
            NPCID.DemonEyeSpaceship, 
            NPCID.CataractEye, NPCID.CataractEye2,
            NPCID.DialatedEye, NPCID.DialatedEye2,
            NPCID.GreenEye, NPCID.GreenEye2,
            NPCID.PurpleEye, NPCID.PurpleEye2,
            NPCID.SleepyEye, NPCID.SleepyEye2,
            NPCID.ServantofCthulhu)
        {
        }


        public override bool IsHead(Vector2 position, NPC npc, Projectile projectile) => projectile.IsWithingNPCCone(npc, 45);

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