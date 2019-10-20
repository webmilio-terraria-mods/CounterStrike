using System.Collections.Generic;
using CounterStrike.Guns;

namespace CounterStrike.Players
{
    public partial class CSPlayer
    {
        private Dictionary<GunDefinition, int> _ammo;


        public int GetAmmoCount(GunDefinition gun)
        {
            CheckAmmo(gun);

            return _ammo[gun];
        }

        public bool HasAmmo(GunDefinition gun) => GetAmmoCount(gun) > 0 || true;
        public bool HasPurchasedThisSession(GunDefinition gun) => _ammo.ContainsKey(gun);


        public bool TryBuyGun(GunDefinition gun)
        {
            if (Money < gun.Price)
                return false;

            CheckAmmo(gun);

            _ammo[gun] = gun.ClipSize * 2;
            Money -= gun.Price;

            return true;
        }


        public IEnumerable<GunDefinition> OwnedAmmo() => _ammo.Keys;


        private void CheckAmmo(GunDefinition gun)
        {
            if (!_ammo.ContainsKey(gun))
                _ammo.Add(gun, 0);
        }


        private void InitializeGuns()
        {
            _ammo = new Dictionary<GunDefinition, int>();
        }


        public bool Reloading { get; set; }
    }
}
