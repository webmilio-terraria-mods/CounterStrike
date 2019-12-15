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


        public override bool IsHead(Vector2 position, NPC npc, Projectile projectile) => position.Y < 20.5f;

        public override bool IsChestArms(Vector2 position, NPC npc, Projectile projectile) => 
            position.Y >= 20.5f && position.Y < 58f; // Since he's holding a shield, we treat his entire body as a "chest".

        public override bool IsAbdomenPelvis(Vector2 position, NPC npc, Projectile projectile) => false;

        public override bool IsLegs(Vector2 position, NPC npc, Projectile projectile) => false;
    }
}