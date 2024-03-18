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

namespace BaseMisc.Music
{
    public class Jukebox
    {
        public static TechType jukeboxTechType;

        public static void RegisterJukebox()
        {
            CustomPrefab jukeboxPrefab = new CustomPrefab("jukebox", "Jukebox", "Controls the music that is played out your speakers", SpriteManager.Get(TechType.Seamoth));

            jukeboxTechType = jukeboxPrefab.Info.TechType;

            jukeboxPrefab.SetGameObject(GetJukeboxPrefab("jukebox", Loading.TheAssetBundle.LoadAsset<GameObject>("Jukebox")));

            RecipeData jukeboxRecipe = new RecipeData
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
                {
                    new Ingredient(TechType.Titanium, 1)
                },
            };

            jukeboxPrefab.SetRecipe(jukeboxRecipe).WithCraftingTime(3f);

            jukeboxPrefab.SetUnlock(TechType.AdvancedWiringKit);

            jukeboxPrefab.SetPdaGroupCategory(TechGroup.Miscellaneous, TechCategory.Misc);

            jukeboxPrefab.Register();
        }

        private static GameObject GetJukeboxPrefab(string classID, GameObject jukeboxPrefabGO)
        {
            PrefabUtils.AddBasicComponents(jukeboxPrefabGO, classID, jukeboxTechType, LargeWorldEntity.CellLevel.Near);

            float scale = .6f;
            jukeboxPrefabGO.transform.localScale = new Vector3(scale, scale, scale);

            GameObject model = jukeboxPrefabGO.transform.Find("JukeboxModel").gameObject;

            Constructable constructable = jukeboxPrefabGO.EnsureComponent<Constructable>();
            constructable.techType = jukeboxTechType;
            constructable.model = model;
            constructable.allowedOnWall = true;
            constructable.allowedOnGround = false;
            constructable.allowedInBase = true;
            constructable.allowedInSub = true;
            constructable.allowedUnderwater = true;

            constructable.ghostMaterial = MaterialUtils.GhostMaterial;

            ConstructableFlags flags = ConstructableFlags.Wall | ConstructableFlags.Base | ConstructableFlags.Inside |
            ConstructableFlags.Submarine;

            PrefabUtils.AddConstructable(jukeboxPrefabGO, jukeboxTechType, flags, model);

            MaterialUtils.ApplySNShaders(model, 4f, 1f, 1f);


            jukeboxPrefabGO.transform.Find("Canvas/ButtonTypeDefault").GetComponent<Button>().onClick.AddListener(MusicController.ChangeMusicTypeToDefault);
            jukeboxPrefabGO.transform.Find("Canvas/ButtonTypeCustom").GetComponent<Button>().onClick.AddListener(MusicController.ChangeMusicTypeToCustom);
            jukeboxPrefabGO.transform.Find("Canvas/ButtonStop").GetComponent<Button>().onClick.AddListener(MusicController.StopMusic);
            jukeboxPrefabGO.transform.Find("Canvas/ButtonPlay").GetComponent<Button>().onClick.AddListener(MusicController.StartMusic);
            jukeboxPrefabGO.transform.Find("Canvas/ButtonSkip").GetComponent<Button>().onClick.AddListener(MusicController.ForwardMusic);
            jukeboxPrefabGO.transform.Find("Canvas/ButtonBack").GetComponent<Button>().onClick.AddListener(MusicController.BackMusic);

            return jukeboxPrefabGO;
        }
    }
}
