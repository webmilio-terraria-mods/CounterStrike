using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace CounterStrike.HitBoxes
{
    public abstract class HeadOnlyHitBox : HitBox
    {
        protected HeadOnlyHitBox(params int[] npcIDs) : base(npcIDs)
        {
        }


        public override bool IsHead(NPC npc, Vector2 position) => true;

        public override bool IsChestArms(NPC npc, Vector2 position) => false;

        public override bool IsAbdomenPelvis(NPC npc, Vector2 position) => false;

        public override bool IsLegs(NPC npc, Vector2 position) => false;
    }


    #region Neutrals

    public class BirdHitBox : HeadOnlyHitBox
    {
        public BirdHitBox() : base(NPCID.Bird, NPCID.BirdBlue, NPCID.BirdRed, NPCID.GoldBird)
        {
        }
    }

    public class SquirrelHitBox : HeadOnlyHitBox
    {
        public SquirrelHitBox() : base(NPCID.Squirrel, NPCID.SquirrelRed, NPCID.SquirrelGold)
        {
        }
    }

    public class BunnyHitBox : HeadOnlyHitBox
    {
        public BunnyHitBox() : base(NPCID.Bunny, NPCID.BunnySlimed, NPCID.BunnyXmas, NPCID.CorruptBunny, NPCID.CrimsonBunny, NPCID.GoldBunny, NPCID.PartyBunny)
        {
        }
    }

    #endregion

    #region Fish Bait

    public class FrogHitBox : HeadOnlyHitBox
    {
        public FrogHitBox() : base(NPCID.Frog, NPCID.GoldFrog)
        {
        }
    }

    public class GrasshopperHitBox : HeadOnlyHitBox
    {
        public GrasshopperHitBox() : base(NPCID.Grasshopper, NPCID.GoldGrasshopper)
        {
        }
    }

    public class WormHitBox : HeadOnlyHitBox
    {
        public WormHitBox() : base(NPCID.Worm, NPCID.GoldWorm)
        {
        }
    }

    public class ScorpinHitBox : HeadOnlyHitBox
    {
        public ScorpinHitBox() : base(NPCID.Scorpion, NPCID.ScorpionBlack)
        {
        }
    }

    public class ButterflyHitBox : HeadOnlyHitBox
    {
        public ButterflyHitBox() : base(NPCID.Butterfly, NPCID.GoldButterfly)
        {
        }
    }

    public class FlyBugHitBox : HeadOnlyHitBox
    {
        public FlyBugHitBox() : base(NPCID.LightningBug, NPCID.Firefly)
        {
        }
    }

    public class SnailHitBox : HeadOnlyHitBox
    {
        public SnailHitBox() : base(NPCID.Buggy, NPCID.Sluggy, NPCID.Grubby, NPCID.GlowingSnail)
        {
        }
    }

    #endregion
}