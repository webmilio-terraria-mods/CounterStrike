using Microsoft.Xna.Framework;
using Terraria;

namespace CounterStrike.HitBoxes.Humanoid.Standard
{
    public abstract class StandardHumanoidHitBox : HitBox
    {
        protected StandardHumanoidHitBox(params int[] npcIDs) : base(npcIDs)
        {
        }


        public override bool IsHead(Vector2 position, NPC npc, Projectile projectile) => projectile.velocity.Y > projectile.velocity.Length() / 2 && position.Y < 15f || position.Y > 3f && position.Y < 15f;

        public override bool IsChestArms(Vector2 position, NPC npc, Projectile projectile) => position.Y < 22f;

        public override bool IsAbdomenPelvis(Vector2 position, NPC npc, Projectile projectile) => position.Y < 28f;

        public override bool IsLegs(Vector2 position, NPC npc, Projectile projectile) => position.Y < npc.height; // The hitbox isn't that big but this gives us a bit of room in case we calculated it wrong.
    }
}