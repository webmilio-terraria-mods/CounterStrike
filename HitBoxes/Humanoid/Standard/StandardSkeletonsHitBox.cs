using Terraria.ID;

namespace CounterStrike.HitBoxes.Humanoid.Standard
{
    public class StandardSkeletonsHitBox : StandardHumanoidHitBox
    {
        public StandardSkeletonsHitBox() : base(
            NPCID.Skeleton, NPCID.HeadacheSkeleton, NPCID.MisassembledSkeleton, NPCID.PantlessSkeleton, 
            NPCID.UndeadMiner,
            NPCID.ArmoredViking, NPCID.UndeadViking,
            NPCID.SkeletonTopHat, NPCID.SkeletonAstonaut, NPCID.SkeletonAlien,

            NPCID.Tim,
            NPCID.GreekSkeleton,

            // Dungeon
            NPCID.AngryBones, NPCID.AngryBonesBigMuscle, NPCID.AngryBonesBigHelmet,

            // Hardmode 
            NPCID.RuneWizard,
            NPCID.ArmoredSkeleton, NPCID.SkeletonArcher,

            // Dungeon
            NPCID.BlueArmoredBones, NPCID.BlueArmoredBonesMace, NPCID.BlueArmoredBonesNoPants, NPCID.BlueArmoredBonesSword,
            NPCID.DarkCaster, NPCID.DiabolistRed, 
            NPCID.BoneLee, NPCID.SkeletonSniper, NPCID.SkeletonCommando, NPCID.TacticalSkeleton,
            
            // Post Plantera
            NPCID.RustyArmoredBonesAxe, NPCID.RustyArmoredBonesFlail, NPCID.RustyArmoredBonesSword, NPCID.RustyArmoredBonesSwordNoArmor,
            NPCID.Necromancer, NPCID.RaggedCaster, NPCID.RaggedCasterOpenCoat,
            NPCID.HellArmoredBones, NPCID.HellArmoredBonesMace, NPCID.HellArmoredBonesSpikeShield, NPCID.HellArmoredBonesSword)
        {
        }
    }
}