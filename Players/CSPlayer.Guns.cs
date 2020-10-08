using System.Collections.Generic;
using CounterStrike.Guns;
using Terraria;
using Terraria.ModLoader;
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


        public bool UIBuyGun(GunDefinition gun)
        {
            if (player.inventory.Find<GunItem>(i => i.modItem is GunItem item && item.Definition == gun) == default)
            {
                TryBuyGun(gun);
                TryFillAmmo(gun);
            }
            else
            {
                TryFillAmmo(gun);
            }

            return true;
        }

        public bool TryBuyGun(GunDefinition gun)
        {
            if (Money < gun.Price)
                return false;

            Money -= gun.Price;
            player.QuickSpawnItem(gun.GunItem);

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


        public override void OnRespawn(Player plr)
        {
            var csPlayer = Get(plr);

            csPlayer.Money = 800;
            csPlayer._ammo.Clear();
        }


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
