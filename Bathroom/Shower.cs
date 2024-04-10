using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Crafting;
using Nautilus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static CraftData;

namespace BaseMisc.Bathroom
{
    public class Shower
    {
        public static TechType techType;

        public static void Register()
        {
            CustomPrefab showerPrefab = new CustomPrefab("shower", "Shower", "A compact luxurious shower to wash off all the day's worries", SpriteManager.Get(TechType.Exosuit));

            techType = showerPrefab.Info.TechType;

            showerPrefab.SetGameObject(GetShowerGameobject("shower", Loading.TheAssetBundle.LoadAsset<GameObject>("Shower"), techType));

            RecipeData showerRecipe = new RecipeData
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
                {
                    new Ingredient(TechType.Titanium, 1),
                    new Ingredient(TechType.Glass, 2),
                    new Ingredient(TechType.Pipe, 1)
                },
            };

            showerPrefab.SetRecipe(showerRecipe).WithCraftingTime(3f);

            showerPrefab.SetUnlock(TechType.FiltrationMachine);

            showerPrefab.SetPdaGroupCategory(TechGroup.Miscellaneous, TechCategory.Misc);

            showerPrefab.Register();
        }

        public static GameObject GetShowerGameobject(string classID, GameObject prefabGO, TechType techType)
        {
            PrefabUtils.AddBasicComponents(prefabGO, classID, techType, LargeWorldEntity.CellLevel.Near);

            float scale = 1f;
            prefabGO.transform.localScale = new Vector3(scale, scale, scale);

            GameObject model = prefabGO.transform.Find("ShowerModel").gameObject;

            MaterialUtils.ApplySNShaders(model, 4f, 1f, 1f);

            return prefabGO;
        }
    }
}
