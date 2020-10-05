using System.Collections.Generic;
using CounterStrike.HitBoxes;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Loaders;

namespace CounterStrike.NPCs
{
    public class CSNPCHitBoxesLoader : SingletonLoader<CSNPCHitBoxesLoader, HitBox>
    {
        private readonly Dictionary<int, HitBox> _hitBoxesByNPCId = new Dictionary<int, HitBox>();


        protected override void PostAdd(Mod mod, HitBox hitBox)
        {
            int[] npcIDs = hitBox.NPCIDs;

            for (int i = 0; i < npcIDs.Length; i++)
                _hitBoxesByNPCId.Add(npcIDs[i], hitBox);
        }


        public HitBox GetByNPC(NPC npc) => GetByNPC(npc.type);
        public HitBox GetByNPC(ModNPC modNPC) => GetByNPC(modNPC.npc);

        public HitBox GetByNPC(int npcId) => _hitBoxesByNPCId[npcId];


        public bool TryGetByNPC(NPC npc, out HitBox hitBox) => TryGetByNPC(npc.type, out hitBox);
        public bool TryGetByNPC(ModNPC modNPC, out HitBox hitBox) => TryGetByNPC(modNPC.npc, out hitBox);

        public bool TryGetByNPC(int npcId, out HitBox hitBox)
        {
            hitBox = default;

            if (!_hitBoxesByNPCId.ContainsKey(npcId))
                return false;

            hitBox = _hitBoxesByNPCId[npcId];
            return true;
        }


        protected override void PostUnload()
        {
            _hitBoxesByNPCId.Clear();
        }


        public HitBox this[NPC npc] => GetByNPC(npc);
        public HitBox this[ModNPC modNPC] => GetByNPC(modNPC);
        public HitBox this[int npcId] => GetByNPC(npcId);
    }
}