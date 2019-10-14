using CounterStrike.Items;
using Terraria.ID;

namespace CounterStrike.Guns
{
    public abstract class CSGun : CSItem
    {
        protected CSGun(string displayName, string tooltip, int width, int height, GunDefinition definition, int rarity = ItemRarityID.White) : 
            base(displayName, tooltip, width, height, value: 0, rarity: rarity, defense: 0)
        {
            Definition = definition;
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.ranged = true;
            item.maxStack = 1;

            item.useStyle = ItemUseStyleID.HoldingOut;
            
        }


        public GunDefinition Definition { get; }
    }
}