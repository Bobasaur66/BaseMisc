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
using System.Collections;
using static Nautilus.Assets.PrefabTemplates.FabricatorTemplate;

namespace BaseMisc.Beds
{
    public class BedBase
    {
        public static IEnumerator GetBedGameObjectAsync(GameObject bedPrefabGO, string classId, TechType techType, IOut<GameObject> gameObject)
        {
            PrefabUtils.AddBasicComponents(bedPrefabGO, classId, techType, LargeWorldEntity.CellLevel.Near);

            float scale = 1f;
            bedPrefabGO.transform.localScale = Vector3.one * scale;

            MaterialUtils.ApplySNShaders(bedPrefabGO, 1f, 1f, 1f);

            var task = CraftData.GetPrefabForTechTypeAsync(TechType.Bed2);
            yield return task;
            var largeBed = task.GetResult();

            var bedAnimator = bedPrefabGO.transform.Find("LargeBed").GetComponent<Animator>();
            bedAnimator.runtimeAnimatorController = largeBed.GetComponentInChildren<Animator>().runtimeAnimatorController;
            bedAnimator.avatar = largeBed.GetComponentInChildren<Animator>().avatar;

            gameObject.Set(bedPrefabGO);
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
