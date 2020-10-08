using System.Collections;
using System.Collections.Generic;
using WebmilioCommons.Managers;

namespace CounterStrike.Guns.Categories
{
    public abstract class GunCategory : IHasUnlocalizedName, IEnumerable<GunDefinition>
    {
        private readonly List<GunDefinition> _guns = new List<GunDefinition>();

        protected GunCategory(string unlocalizedName, string displayName)
        {
            UnlocalizedName = unlocalizedName;
            DisplayName = displayName;
        }


        public void Add(GunDefinition gun)
        {
            _guns.Add(gun);
        }


        public IEnumerator<GunDefinition> GetEnumerator() => _guns.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        public string UnlocalizedName { get; }
        public string DisplayName { get; }

        public int Id => GunCategories.Instance.GetId(this);

        public int Count => _guns.Count;

        public GunDefinition this[int index] => _guns[index];
    }
}