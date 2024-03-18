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
using UnityEngine.UI;
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

            techType = jukeboxPrefab.Info.TechType;

            jukeboxPrefab.SetGameObject(GetJukeboxPrefab("jukebox", Loading.TheAssetBundle.LoadAsset<GameObject>("Jukebox")));

            RecipeData jukerboxRecipe = new RecipeData
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
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

            float scale = .6f;
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

            MaterialUtils.ApplySNShaders(model, 4f, 1f, 1f);

            jukeboxPrefabGO.FindChild("Canvas/ButtonTypeDefault").GetComponent<Button>().onClick.AddListener(MusicController.ChangeMusicTypeToDefault);
            jukeboxPrefabGO.FindChild("Canvas/ButtonTypeCustom").GetComponent<Button>().onClick.AddListener(MusicController.ChangeMusicTypeToCustom);
            jukeboxPrefabGO.FindChild("Canvas/ButtonStop").GetComponent<Button>().onClick.AddListener(MusicController.StopMusic);
            jukeboxPrefabGO.FindChild("Canvas/ButtonPlay").GetComponent<Button>().onClick.AddListener(MusicController.StartMusic);
            jukeboxPrefabGO.FindChild("Canvas/ButtonSkip").GetComponent<Button>().onClick.AddListener(MusicController.ForwardMusic);
            jukeboxPrefabGO.FindChild("Canvas/ButtonBack").GetComponent<Button>().onClick.AddListener(MusicController.BackMusic);

            return jukeboxPrefabGO;
        }
    }
}
