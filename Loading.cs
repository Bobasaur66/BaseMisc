using BaseMisc.Beds;
using Nautilus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BaseMisc
{
    public class Loading
    {
        public static AssetBundle TheAssetBundle { get; set; }

        public static void LoadAllAssets()
        {
            TheAssetBundle = AssetBundleLoadingUtils.LoadFromAssetsFolder(Assembly.GetExecutingAssembly(), "basemisc");


        }

        public static void RegisterAllPrefabs()
        {
            BlueBed.Register();


        }
    }
}
