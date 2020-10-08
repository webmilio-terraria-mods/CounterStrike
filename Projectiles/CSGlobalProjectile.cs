using System.Collections.Generic;
using CounterStrike.Guns;
using Terraria;
using Terraria.ModLoader;

namespace CounterStrike.Projectiles
{
    public sealed class CSGlobalProjectile : GlobalProjectile
    {
        public static Dictionary<Projectile, GunDefinition> gunDefinitionPerProjectile;


        public override bool PreAI(Projectile projectile)
        {
            if (!projectile.ranged || gunDefinitionPerProjectile.ContainsKey(projectile))
                return true;

            Player player = Main.player[projectile.owner];

            if (player.HeldItem?.modItem == null || !(player.HeldItem.modItem is GunItem gun))
                return true;

            gunDefinitionPerProjectile.Add(projectile, gun.Definition);
            return true;
        }


        public override void Kill(Projectile projectile, int timeLeft)
        {
            if (gunDefinitionPerProjectile.ContainsKey(projectile))
                gunDefinitionPerProjectile.Remove(projectile);
        }
    }
}