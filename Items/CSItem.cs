using Terraria.ID;
using Terraria.ModLoader;

namespace CounterStrike.Items
{
    public abstract class CSItem : ModItem
    {
        public readonly string displayName, tooltip; // These aren't properties because they already exists in ModItem.
        private readonly int _width, _height;


        protected CSItem(string displayName, string tooltip, int width, int height, int value = 0, int rarity = ItemRarityID.White, int defense = 0)
        {
            this.displayName = displayName;
            this.tooltip = tooltip;

            _width = width;
            _height = height;

            Value = value;
            Rarity = rarity;
            Defense = defense;
        }


        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault(displayName);
            Tooltip.SetDefault(tooltip);
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.width = _width;
            item.height = _height;

            item.value = Value;
            item.rare = Rarity;
            item.defense = Defense;
        }


        public int Value { get; }
        public int Rarity { get; }
        public int Defense { get; }
    }
}