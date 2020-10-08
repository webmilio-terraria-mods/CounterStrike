using System;
using CounterStrike.UserInterfaces.KillFeed;
using Microsoft.Xna.Framework;
using Terraria;

namespace CounterStrike.Players
{
    public sealed partial class CSPlayer
    {
        private void ModifyHitNPCKillFeed(Item item, Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit)
        {

        }

        public void OnKillNPC(NPC target)
        {
            if (target.friendly)
                return;

            // Need to add a better check than this.
            CSMod.Instance.KillFeedLayer.KillFeedUIState.KillFeedElement.KillFeedEntries.Add(new KillFeedEntry(player.name, target.FullName));

            var previous = Money;
            var delta = (int)Math.Ceiling(target.value * 0.08f);
            var current = ModifyMoney(delta);

            if (player.NPCBannerBuff[target.type] && delta > 0)
                delta = delta + (int)(delta * 0.15f);

            if (delta != 0 && previous != current)
            {
                CombatText.NewText(new Rectangle((int)target.position.X, (int)target.Bottom.Y + target.height * 2, target.width, 0),
                    delta < 0 ? Color.Red : Color.LightGreen, $"+{delta}", delta < 0);
            }
        }
    }
}
