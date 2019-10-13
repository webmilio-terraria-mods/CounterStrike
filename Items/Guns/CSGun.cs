namespace CounterStrike.Items.Guns
{
    public abstract class CSGun : CSItem
    {
        protected CSGun(string displayName, string tooltip, int width, int height, int rarity) : 
            base(displayName, tooltip, width, height, value: 0, rarity: rarity, defense: 0)
        {
        }



    }
}