using System;
using CounterStrike.Commands.Debug;
using CounterStrike.Guns;
using CounterStrike.HitBoxes;
using CounterStrike.Players;
using CounterStrike.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace CounterStrike.NPCs
{
    public sealed class CSGlobalNPC : GlobalNPC
    {
        private static Projectile _testProj = new Projectile();


        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            //crit = false;
            if (!CSNPCHitBoxesLoader.Instance.TryGetByNPC(npc, out var hitBox))
                return;

            if (!CSGlobalProjectile.gunDefinitionPerProjectile.ContainsKey(projectile)) // Makes only guns from this mod capable of using hitboxes.
                return;

            var gunDefinition = CSGlobalProjectile.gunDefinitionPerProjectile[projectile];
            var hitPosition = new Vector2(Math.Abs(npc.position.X - projectile.position.X), Math.Abs(npc.position.Y - projectile.position.Y));


            if (hitBox.IsHead(hitPosition, npc, projectile))
            {
                damage = (int) (damage * gunDefinition.DamageProperties.headMultiplier);
            }
            else if (hitBox.IsChestArms(hitPosition, npc, projectile))
                damage = (int) (damage * gunDefinition.DamageProperties.chestArmsMultiplier);
            else if (hitBox.IsAbdomenPelvis(hitPosition, npc, projectile))
                damage = (int) (damage * gunDefinition.DamageProperties.abdomenPelvisMultiplier);
            else if (hitBox.IsLegs(hitPosition, npc, projectile))
                damage = (int) (damage * gunDefinition.DamageProperties.legsMultiplier);

            base.ModifyHitByProjectile(npc, projectile, ref damage, ref knockback, ref crit, ref hitDirection);
        }


        public override bool PreAI(NPC npc)
        {
            if (!npc.active)
                return base.PreAI(npc);

            return base.PreAI(npc);
        }


        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (!npc.active)
                return;

            if (ShowRotationLineCommand.ShowRotationLine)
                DrawRotationLines(spriteBatch, npc);

            if (ShowHitBoxesCommand.ShowHitBoxes)
                DrawHitBoxes(spriteBatch, npc);
        }

        private void DrawRotationLines(SpriteBatch spriteBatch, NPC npc)
        {
            Vector2 position = npc.Center - Main.screenPosition;

            int
                centerX = (int) position.X,
                centerY = (int) position.Y;

            Rectangle sourceRectangle = new Rectangle(0, 0, 1, 1);

            spriteBatch.Draw(Main.magicPixel, new Rectangle(centerX, centerY, 30, 2), sourceRectangle, Color.Red, npc.boss ? npc.GetBossHeadRotation() : npc.rotation, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(Main.magicPixel, new Rectangle(centerX, centerY, 25, 2), sourceRectangle, Color.Blue, npc.VelocityRotation(), Vector2.Zero, SpriteEffects.None, 0);

            if (npc.target >= 0)
            {
                Player player = Main.player[npc.target];

                int
                    lengthX = (int) (npc.Center.X - player.Center.X),
                    lengthY = (int) (npc.Center.Y - player.Center.Y);

                spriteBatch.Draw(Main.magicPixel, new Rectangle(centerX, centerY, 20, 2), sourceRectangle, Color.Green, (float) (Math.Atan2(lengthY, lengthX) - Math.PI), Vector2.Zero, SpriteEffects.None, 0);
            }
        }

        private void DrawHitBoxes(SpriteBatch spriteBatch, NPC npc)
        {
            if (!CSNPCHitBoxesLoader.Instance.TryGetByNPC(npc, out var hitBox))
                return;

            var position = npc.Center - Main.screenPosition;

            int
                offsetX = (int) position.X,
                offsetY = (int) position.Y;

            var sourceRectangle = new Rectangle(0, 0, 1, 1);

            for (int i = 0; i < npc.height; i++)
            {
                Color hitBoxColor = default;

                var hitPosition = new Vector2(0, Math.Abs(i));
                if (hitBox.IsHead(hitPosition, npc, _testProj))
                    hitBoxColor = Color.Red;
                else if (hitBox.IsChestArms(hitPosition, npc, _testProj))
                    hitBoxColor = Color.DarkGreen;
                else if (hitBox.IsAbdomenPelvis(hitPosition, npc, _testProj))
                    hitBoxColor = Color.Blue;
                else if (hitBox.IsLegs(hitPosition, npc, _testProj))
                    hitBoxColor = Color.Yellow;

                spriteBatch.Draw(Main.magicPixel, new Rectangle(offsetX, (int) (npc.TopLeft.Y - Main.screenPosition.Y) + i, 2, 2), sourceRectangle, hitBoxColor, npc.rotation, Vector2.Zero, SpriteEffects.None, 0);
            }
        }


        public override void NPCLoot(NPC npc)
        {
            if (npc.lastInteraction == 255) return;

            CSPlayer.Get(npc.lastInteraction).OnKillNPC(npc);
        }
    }
}