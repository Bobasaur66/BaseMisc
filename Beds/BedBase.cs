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
using static HandReticle;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;

namespace BaseMisc.Beds
{
    public class BedBase
    {
        public static GameObject GetBedGameobject(string classID, GameObject bedPrefabGO, TechType techType, PrefabInfo info)
        {
            PrefabUtils.AddBasicComponents(bedPrefabGO, classID, techType, LargeWorldEntity.CellLevel.Near);
            
            float scale = 1f;
            bedPrefabGO.transform.localScale = new Vector3(scale, scale, scale);

            GameObject model = bedPrefabGO.transform.Find("LargeBed/BedModel").gameObject;

            MaterialUtils.ApplySNShaders(model, 1f, 1f, 1f);

            //bedPrefabGO.transform.Find("LargeBed").GetComponent<Animator>().runtimeAnimatorController = largeBed.GetComponentInChildren<Animator>().runtimeAnimatorController;

            return bedPrefabGO;
        }

        public static CustomPrefab GetBedCustomPrefab(CustomPrefab prefab)
        {
            RecipeData bedRecipe = new RecipeData
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
                {
                    new Ingredient(TechType.Titanium, 2),
                    new Ingredient(TechType.FiberMesh, 1)
                },
            };

            prefab.SetRecipe(bedRecipe).WithCraftingTime(3f);

            prefab.SetUnlock(TechType.NarrowBed);

            prefab.SetPdaGroupCategory(TechGroup.Miscellaneous, TechCategory.Misc);

            return prefab;
        }
    }
}
