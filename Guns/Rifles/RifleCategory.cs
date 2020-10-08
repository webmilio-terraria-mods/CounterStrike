using CounterStrike.Guns.Categories;

namespace CounterStrike.Guns.Rifles
{
    public class RifleCategory : GunCategory
    {
        public RifleCategory() : base("rifle", "Rifle")
        {
        }


        public static RifleCategory Instance => GunCategories.Instance.GetGeneric<RifleCategory>();
    }
}