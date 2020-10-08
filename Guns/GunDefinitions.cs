using System;
using Terraria.ModLoader;
using WebmilioCommons.Loaders;

namespace CounterStrike.Guns
{
    public sealed class GunDefinitions : SingletonLoader<GunDefinitions, GunDefinition>
    {
        protected override bool PreAdd(Mod mod, GunDefinition gun)
        {
            

            return base.PreAdd(mod, gun);
        }
    }
}