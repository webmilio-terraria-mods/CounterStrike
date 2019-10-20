using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace CounterStrike.HitBoxes
{
    public abstract class SmallCritterHitBox : HitBox
    {
        protected SmallCritterHitBox(params int[] npcIDs) : base(npcIDs)
        {
        }


        public override bool IsHead(NPC npc, Vector2 position) => true;
        public override bool IsChestArms(NPC npc, Vector2 position) => true;
        public override bool IsAbdomenPelvis(NPC npc, Vector2 position) => true;
        public override bool IsLegs(NPC npc, Vector2 position) => true;
    }

    public class BirdHitBox : SmallCritterHitBox
    {
        public BirdHitBox() : base(NPCID.Bird, NPCID.BirdBlue, NPCID.BirdRed, NPCID.GoldBird)
        {
        }
    }

    public class SquirrelHitBox : SmallCritterHitBox
    {
        public SquirrelHitBox() : base(NPCID.Squirrel, NPCID.SquirrelRed, NPCID.SquirrelGold)
        {
        }
    }

    public class BunnyHitBox : SmallCritterHitBox
    {
        public BunnyHitBox() : base(NPCID.Bunny, NPCID.BunnySlimed, NPCID.BunnyXmas, NPCID.CorruptBunny, NPCID.CrimsonBunny, NPCID.GoldBunny, NPCID.PartyBunny)
        {
        }
    }

    #region Fish Bait

    public class FrogHitBox : SmallCritterHitBox
    {
        public FrogHitBox() : base(NPCID.Frog, NPCID.GoldFrog)
        {
        }
    }

    public class GrasshopperHitBox : SmallCritterHitBox
    {
        public GrasshopperHitBox() : base(NPCID.Grasshopper, NPCID.GoldGrasshopper)
        {
        }
    }

    public class WormHitBox : SmallCritterHitBox
    {
        public WormHitBox() : base(NPCID.Worm, NPCID.GoldWorm)
        {
        }
    }

    public class ScorpinHitBox : SmallCritterHitBox
    {
        public ScorpinHitBox() : base(NPCID.Scorpion, NPCID.ScorpionBlack)
        {
        }
    }

    public class ButterflyHitBox : SmallCritterHitBox
    {
        public ButterflyHitBox() : base(NPCID.Butterfly, NPCID.GoldButterfly)
        {
        }
    }

    public class FlyBugHitBox : SmallCritterHitBox
    {
        public FlyBugHitBox() : base(NPCID.LightningBug, NPCID.Firefly)
        {
        }
    }

    public class SnailHitBox : SmallCritterHitBox
    {
        public SnailHitBox() : base(NPCID.Buggy, NPCID.Sluggy, NPCID.Grubby, NPCID.GlowingSnail)
        {
        }
    }

    #endregion
}