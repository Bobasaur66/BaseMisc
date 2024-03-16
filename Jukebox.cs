using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static CraftData;
using static GameObjectPoolPrefabMap;
using static HandReticle;
using static Nautilus.Assets.PrefabTemplates.FabricatorTemplate;

namespace BaseMisc
{
    public class Jukebox
    {
        public static TechType techType;

        public static void RegisterJukebox()
        {
            CustomPrefab jukeboxPrefab = new CustomPrefab("jukebox", "Jukebox", "Controls the music that is played out your speakers", SpriteManager.Get(TechType.Seamoth));
            jukeboxPrefab.SetGameObject(GetJukeboxPrefab("jukebox", Loading.TheAssetBundle.LoadAsset<GameObject>("Jukebox")));

            techType = jukeboxPrefab.Info.TechType;

            RecipeData jukerboxRecipe = new RecipeData
            {
                craftAmount = 1,
                Ingredients =
                {
                    new Ingredient(TechType.Titanium, 1)
                },
            };

            jukeboxPrefab.SetRecipe(jukerboxRecipe).WithCraftingTime(3f);

            jukeboxPrefab.SetUnlock(TechType.AdvancedWiringKit);

            jukeboxPrefab.SetPdaGroupCategory(TechGroup.Miscellaneous, TechCategory.Misc);

            jukeboxPrefab.Register();
        }

        private static GameObject GetJukeboxPrefab(string classID, GameObject jukeboxPrefabGO)
        {
            PrefabUtils.AddBasicComponents(jukeboxPrefabGO, classID, techType, LargeWorldEntity.CellLevel.Near);

            float scale = 1f;
            jukeboxPrefabGO.transform.localScale = new Vector3(scale, scale, scale);

            GameObject model = jukeboxPrefabGO.transform.Find("JukeboxModel").gameObject;

            Constructable constructable = jukeboxPrefabGO.EnsureComponent<Constructable>();
            constructable.techType = techType;
            constructable.model = model;
            constructable.allowedOnWall = true;
            constructable.allowedOnGround = false;
            constructable.allowedInBase = true;
            constructable.allowedInSub = true;
            constructable.allowedUnderwater = true;

            constructable.ghostMaterial = MaterialUtils.GhostMaterial;

            ConstructableFlags flags = ConstructableFlags.Wall | ConstructableFlags.Base | ConstructableFlags.Inside |
            ConstructableFlags.Submarine;

            PrefabUtils.AddConstructable(jukeboxPrefabGO, techType, flags, model);



            return jukeboxPrefabGO;
        }
    }
}
