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


        public override bool IsHead(Vector2 position, NPC npc, Projectile projectile) => false;

        public override bool IsChestArms(Vector2 position, NPC npc, Projectile projectile) => true;

        public override bool IsAbdomenPelvis(Vector2 position, NPC npc, Projectile projectile) => false;

        public override bool IsLegs(Vector2 position, NPC npc, Projectile projectile) => false;
    }
}