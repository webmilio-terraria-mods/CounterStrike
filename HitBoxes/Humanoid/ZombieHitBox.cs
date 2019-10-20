using Terraria.ID;

namespace CounterStrike.HitBoxes.Humanoid
{
    public class ZombieHitBox : StandardHumanoidHitBox
    {
        public ZombieHitBox() : base(NPCID.Zombie, NPCID.ArmedZombie, NPCID.FemaleZombie, NPCID.BaldZombie,
            NPCID.ZombieRaincoat,
            NPCID.TwiggyZombie, NPCID.ArmedZombieTwiggy,
            NPCID.ZombieEskimo, NPCID.ArmedZombieEskimo,
            NPCID.PincushionZombie, NPCID.ArmedZombiePincussion,
            NPCID.SwampZombie, NPCID.ArmedZombieSwamp,
            NPCID.ZombieMushroom, NPCID.ZombieMushroomHat,
            NPCID.DoctorBones, NPCID.TheGroom, NPCID.TheBride,
            NPCID.BloodZombie,
            NPCID.ZombieSuperman, NPCID.ZombiePixie, NPCID.ZombieSweater, NPCID.ZombieXmas)
        {
        }
    }
}