using System.Collections.Generic;
using CounterStrike.Players;
using Terraria;
using WebmilioCommons.Managers;

namespace CounterStrike.Ammo
{
    public abstract class ExtraClipRule : IHasUnlocalizedName
    {
        protected ExtraClipRule(string unlocalizedName)
        {
            UnlocalizedName = unlocalizedName;
        }


        public abstract bool MeetsRequirements(CSPlayer csPlayer);

        public abstract void ExtraClipCount(ref int add, ref float mult, ref int flat);


        public string UnlocalizedName { get; }



        public static List<ExtraClipRule> ExtraClipRules { get; private set; }


        internal static void Load()
        {
            ExtraClipRules = new List<ExtraClipRule>
            {
                new StandardExtraClipRule("kingSlimeDefeated", player => NPC.downedSlimeKing, 1, 1, 0),
                new StandardExtraClipRule("eyeOfCthulhu", player => NPC.downedBoss1, 1, 1, 0)
            };

        }

        internal static void Unload()
        {
            ExtraClipRules = null;
        }
    }
}