using CounterStrike.Guns.Categories;

namespace CounterStrike.Guns.Heavies
{
    public class HeavyCategory : GunCategory
    {
        public HeavyCategory() : base("heavy", "Heavy")
        {
        }


        public static HeavyCategory Instance => GunCategories.Instance.GetGeneric<HeavyCategory>();
    }
}
