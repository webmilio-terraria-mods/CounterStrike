using System.Collections.Generic;
using CounterStrike.Guns;
using Terraria.ModLoader.IO;
using WebmilioCommons.Extensions;

namespace CounterStrike.Players
{
    public partial class CSPlayer
    {
        private bool _gunMounted;

        public bool ToggleMount() => GunMounted = !GunMounted;
        public void MountGun() => GunMounted = true;
        public void DismountGun() => GunMounted = false;


        public bool TryBuyGun(GunDefinition gun)
        {
            if (Money < gun.Price)
                return false;

            CheckAmmo(gun);

            _ammo[gun] = gun.StartingMagazineCount * gun.MagazineSize;
            Money -= gun.Price;

            return true;
        }


        #region Hooks

        private void InitializeGuns()
        {

        }

        private void LoadGuns(TagCompound tag)
        {
            
        }

        private void SaveGuns(TagCompound tag)
        {

        }

        #endregion


        public bool Reloading { get; set; }
        public int ReloadTicks { get; private set; }


        public bool GunMounted
        {
            get => _gunMounted;
            set
            {
                if (_gunMounted == value)
                    return;

                _gunMounted = value;

                this.SendIfLocal<PlayerMountedStatusChanged>();
            }
        }
    }
}
