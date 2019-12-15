using Microsoft.Xna.Framework;
using Terraria;

namespace CounterStrike
{
    public static class CSMath
    {
        public static bool IsWithingNPCCone(this Entity entity, NPC npc, float range) => IsWithinCone(entity, npc.velocity.ToRotation(), range);

        public static bool IsWithinCone(this Entity entity, float originalAngle, float range)
        {
            float
                entityPosition = entity.velocity.ToRotation(),
                entityReversed = entityPosition + MathHelper.Pi,

                lowerBound = originalAngle - MathHelper.ToRadians(range),
                upperBound = originalAngle + MathHelper.ToRadians(range);

            return entityReversed >= lowerBound && entityReversed <= upperBound;
        }
    }
}