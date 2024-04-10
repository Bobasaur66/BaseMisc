using Nautilus.Assets;
using Nautilus.Crafting;
using Nautilus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;
using UnityEngine;
using Nautilus.Assets.Gadgets;

namespace BaseMisc.Bathroom
{
    public class Sink
    {
        public static TechType techType;

        public static void Register()
        {
            CustomPrefab sinkPrefab = new CustomPrefab("sink", "Sink", "The ocean isn't enough to clean your hands", SpriteManager.Get(TechType.Exosuit));

            techType = sinkPrefab.Info.TechType;

            sinkPrefab.SetGameObject(GetSinkGameobject("sink", Loading.TheAssetBundle.LoadAsset<GameObject>("Sink"), techType));

            RecipeData sinkRecipe = new RecipeData
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
                {
                    new Ingredient(TechType.Titanium, 2),
                    new Ingredient(TechType.Pipe, 2)
                },
            };

            sinkPrefab.SetRecipe(sinkRecipe).WithCraftingTime(3f);

            sinkPrefab.SetUnlock(TechType.FiltrationMachine);

            sinkPrefab.SetPdaGroupCategory(TechGroup.Miscellaneous, TechCategory.Misc);

            sinkPrefab.Register();
        }

        public static GameObject GetSinkGameobject(string classID, GameObject prefabGO, TechType techType)
        {
            PrefabUtils.AddBasicComponents(prefabGO, classID, techType, LargeWorldEntity.CellLevel.Near);

            float scale = 1f;
            prefabGO.transform.localScale = new Vector3(scale, scale, scale);

            GameObject model = prefabGO.transform.Find("SinkModel").gameObject;

            MaterialUtils.ApplySNShaders(model, 4f, 1f, 1f);

            return prefabGO;
        }
    }
}
