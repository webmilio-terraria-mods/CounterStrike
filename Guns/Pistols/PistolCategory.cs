using CounterStrike.Guns.Categories;

namespace CounterStrike.Guns.Pistols
{
    public class PistolCategory : GunCategory
    {
        public PistolCategory() : base("pistol", "Pistol")
        {
        }


        public static PistolCategory Instance => GunCategories.Instance.GetGeneric<PistolCategory>();
    }
}