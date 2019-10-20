using System;
using CounterStrike.UserInterfaces.KillFeed;
using Terraria;

namespace CounterStrike.Players
{
    public sealed partial class CSPlayer
    {
        private void ModifyHitNPCKillFeed(Item item, Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (target.life - damage > 0)
                return;

            // Need to add a better check than this.
            CSMod.Instance.KillFeedLayer.KillFeedUIState.KillFeedElement.KillFeedEntries.Add(new KillFeedEntry(player.name, target.FullName));
            ModifyMoney((int) Math.Ceiling(target.value * 0.05f));
        }
    }
}
