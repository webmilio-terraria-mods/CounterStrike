using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStrike.Ammo;
using CounterStrike.Guns;
using Terraria.ModLoader.IO;

namespace CounterStrike.Players
{
    public sealed partial class CSPlayer
    {
        private const string AMMO_TAG = "Ammo";

        private Dictionary<GunDefinition, int> _ammo;


        // Ammo checks
        private void CheckAmmo(GunDefinition gun)
        {
            if (!_ammo.ContainsKey(gun))
                _ammo.Add(gun, 0);
        }

        public int GetAmmoCount(GunDefinition gun)
        {
            CheckAmmo(gun);

            return _ammo[gun];
        }

        public bool HasAmmo(GunDefinition gun) => GetAmmoCount(gun) > 0;


        public Dictionary<GunDefinition, int>.KeyCollection OwnedAmmo() => _ammo.Keys;


        public int GetMaxAmmo(GunDefinition gun) => GetMaxClips(gun) * gun.MagazineSize;

        public int GetMaxClips(GunDefinition gun) => gun.StartingMagazineCount + SpareClips;

        public float GetMaxMagazines(GunDefinition gun) => GetMaxAmmo(gun) / (float) gun.MagazineSize;


        public int GetMissingAmmo(GunDefinition gun) => GetMaxAmmo(gun) - GetAmmoCount(gun);

        public bool HasSpaceForAmmo(GunDefinition gun, int ammoCount = 1) => GetMissingAmmo(gun) >= ammoCount;


        // Buying
        private void BuyAmmo(GunDefinition gun, int count = 1)
        {
            CheckAmmo(gun);

            _ammo[gun] += count;
        }

        public bool TryBuyAmmo(GunDefinition gun)
        {
            if (!HasSpaceForAmmo(gun) || gun.BulletCost > Money)
                return false;

            BuyAmmo(gun);
            return true;
        }

        public bool TryFillAmmo(GunDefinition gun)
        {
            int buyable = GetMissingAmmo(gun);
            float cost = gun.BulletCost * buyable;

            // HasSpaceForAmmo is redundant since it uses GetBuyableAmmo.
            if (!HasSpaceForAmmo(gun, buyable) || cost > Money)
                return false;

            BuyAmmo(gun, buyable);
            return true;
        }

        public int BuyMostAmmo(GunDefinition gun)
        {
            int toBuy = GetMissingAmmo(gun);

            while (toBuy * gun.BulletCost > Money && toBuy > 0)
                toBuy--;

            BuyAmmo(gun, toBuy);
            return toBuy;
        }


        #region Hooks

        private void InitializeAmmo()
        {
            _ammo = new Dictionary<GunDefinition, int>();
        }

        
        private void LoadAmmo(TagCompound tag)
        {
            foreach (KeyValuePair<string, object> ammoTag in tag.GetCompound(AMMO_TAG))
            {
                GunDefinition gun = GunDefinitionLoader.Instance.FindGeneric(g => g.UnlocalizedName.Equals(ammoTag.Key, StringComparison.CurrentCultureIgnoreCase));

                if (gun == default)
                    continue;

                _ammo.Add(gun, int.Parse(ammoTag.Value.ToString()));
            }
        }


        private void ResetEffectsAmmo()
        {
            SpareClips = 0;

            for (int i = 0; i < ExtraClipRule.ExtraClipRules.Count; i++)
                if (ExtraClipRule.ExtraClipRules[i].MeetsRequirements(this))
                {
                    int 
                        add = 0, 
                        flat = 0;
                    float mult = 1;

                    ExtraClipRule.ExtraClipRules[i].ExtraClipCount(ref add, ref mult, ref flat);
                }
        }


        private void SaveAmmo(TagCompound tag)
        {
            TagCompound ammoTag = new TagCompound();

            foreach (KeyValuePair<GunDefinition, int> ammo in _ammo)
                ammoTag.Add(ammo.Key.UnlocalizedName, ammo.Value);

            tag.Add(AMMO_TAG, ammoTag);
        }

        #endregion


        public int SpareClips { get; set; }
    }
}
