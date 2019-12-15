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


        public override bool IsHead(Vector2 position, NPC npc, Projectile projectile) => false;

        public override bool IsChestArms(Vector2 position, NPC npc, Projectile projectile) => true;

        public override bool IsAbdomenPelvis(Vector2 position, NPC npc, Projectile projectile) => false;

        public override bool IsLegs(Vector2 position, NPC npc, Projectile projectile) => false;
    }
}