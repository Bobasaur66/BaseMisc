using Nautilus.Assets;
using Nautilus.Crafting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;
using UnityEngine;
using Nautilus.Assets.Gadgets;

namespace BaseMisc.Beds
{
    public class BlueBed
    {
        public static TechType techType;

        public static void Register()
        {
            CustomPrefab blueBedPrefab = new CustomPrefab("blueBed", "Blue Bed", "A nice cosy bed spend the night in", SpriteManager.Get(TechType.Exosuit));

            techType = blueBedPrefab.Info.TechType;

            blueBedPrefab.SetGameObject(BedBase.GetBedGameobject("blueBed", Loading.TheAssetBundle.LoadAsset<GameObject>("BlueBed"), techType));

            blueBedPrefab = BedBase.GetBedCustomPrefab(blueBedPrefab);

            blueBedPrefab.Register();
        }
    }
}
