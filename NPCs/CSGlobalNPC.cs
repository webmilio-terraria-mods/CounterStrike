using System;
using CounterStrike.Guns;
using CounterStrike.HitBoxes;
using CounterStrike.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CounterStrike.NPCs
{
    public sealed class CSGlobalNPC : GlobalNPC
    {
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            //crit = false;
            HitBox hitBox = CSNPCHitBoxes.Instance[npc];

            if (hitBox == null)
                return;

            if (!CSGlobalProjectile.gunDefinitionPerProjectile.ContainsKey(projectile)) // Makes only guns from this mod capable of using hitboxes.
                return;

            GunDefinition gunDefinition = CSGlobalProjectile.gunDefinitionPerProjectile[projectile];

            Vector2 hitPosition = new Vector2(Math.Abs(npc.position.X - projectile.position.X), Math.Abs(npc.position.Y - projectile.position.Y));

            if (hitBox.IsHead(npc, hitPosition))
            {
                damage = (int) (damage * gunDefinition.DamageProperties.headMultiplier);
            }
            else if (hitBox.IsChestArms(npc, hitPosition))
                damage = (int) (damage * gunDefinition.DamageProperties.chestArmsMultiplier);
            else if (hitBox.IsAbdomenPelvis(npc, hitPosition))
                damage = (int) (damage * gunDefinition.DamageProperties.abdomenPelvisMultiplier);
            else if (hitBox.IsLegs(npc, hitPosition))
                damage = (int) (damage * gunDefinition.DamageProperties.legsMultiplier);

            base.ModifyHitByProjectile(npc, projectile, ref damage, ref knockback, ref crit, ref hitDirection);
        }
    }
}