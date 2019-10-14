using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStrike.UserInterfaces.KillFeed;
using Terraria;

namespace CounterStrike.Players
{
    public sealed partial class CSPlayer
    {
        private void ModifyHitNPCKillFeed(Item item, Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (target.life - damage <= 0)
                CSMod.Instance.KillFeedLayer.KillFeedUIState.KillFeedElement.KillFeedEntries.Add(new KillFeedEntry(player.name, target.FullName));
        }
    }
}
