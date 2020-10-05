using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace CounterStrike.HitBoxes.Slimes
{
    public class StandardSlimeHitBox : HitBox
    {
        public StandardSlimeHitBox() : base(
            NPCID.BlueSlime, NPCID.GreenSlime, NPCID.PurpleSlime, NPCID.Pinky, NPCID.YellowSlime, NPCID.BlackSlime, NPCID.MotherSlime, NPCID.LavaSlime, NPCID.CorruptSlime,
            NPCID.BabySlime, NPCID.SpikedJungleSlime, NPCID.SandSlime, NPCID.RedSlime, NPCID.IceSlime)
        {
        }


        public override bool IsHead(Vector2 position, NPC npc, Projectile projectile) => false;

        public override bool IsChestArms(Vector2 position, NPC npc, Projectile projectile) => false;

        public override bool IsAbdomenPelvis(Vector2 position, NPC npc, Projectile projectile) => true;

        public override bool IsLegs(Vector2 position, NPC npc, Projectile projectile) => false;
    }
}