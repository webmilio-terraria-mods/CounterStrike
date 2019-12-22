using System;
using CounterStrike.Commands.Debug;
using CounterStrike.Guns;
using CounterStrike.HitBoxes;
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
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            //crit = false;
            HitBox hitBox = CSNPCHitBoxesLoader.Instance[npc];

            if (hitBox == null)
                return;

            if (!CSGlobalProjectile.gunDefinitionPerProjectile.ContainsKey(projectile)) // Makes only guns from this mod capable of using hitboxes.
                return;

            GunDefinition gunDefinition = CSGlobalProjectile.gunDefinitionPerProjectile[projectile];

            Vector2 hitPosition = new Vector2(Math.Abs(npc.position.X - projectile.position.X), Math.Abs(npc.position.Y - projectile.position.Y));

            

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
        }

        private void DrawRotationLines(SpriteBatch spriteBatch, NPC npc)
        {
            Vector2 position = npc.Center - Main.screenPosition;

            int
                centerX = (int) position.X,
                centerY = (int) position.Y;

            Rectangle sourceRectangle = new Rectangle(0, 0, 1, 1);

            if (npc.boss)
                spriteBatch.Draw(Main.magicPixel, new Rectangle(centerX, centerY, 30, 2), sourceRectangle, Color.Red, npc.GetBossHeadRotation(), Vector2.Zero, SpriteEffects.None, 0);
            else
                spriteBatch.Draw(Main.magicPixel, new Rectangle(centerX, centerY, 30, 2), sourceRectangle, Color.Red, npc.rotation, Vector2.Zero, SpriteEffects.None, 0);

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
    }
}