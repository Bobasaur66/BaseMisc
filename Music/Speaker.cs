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

namespace BaseMisc.Music
{
    public class Speaker
    {
        public static TechType speakerTechType;

        public static void RegisterSpeaker()
        {
            CustomPrefab speakerPrefab = new CustomPrefab("speaker", "Speaker", "Plays the music you set in the jukebox", SpriteManager.Get(TechType.Exosuit));

            speakerTechType = speakerPrefab.Info.TechType;

            speakerPrefab.SetGameObject(GetSpeakerPrefab("speaker", Loading.TheAssetBundle.LoadAsset<GameObject>("Speaker")));

            RecipeData speakerRecipe = new RecipeData
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
                {
                    new Ingredient(TechType.Titanium, 1)
                },
            };

            speakerPrefab.SetRecipe(speakerRecipe).WithCraftingTime(3f);

            speakerPrefab.SetUnlock(TechType.AdvancedWiringKit);

            speakerPrefab.SetPdaGroupCategory(TechGroup.Miscellaneous, TechCategory.Misc);

            speakerPrefab.Register();
        }

        private static GameObject GetSpeakerPrefab(string classID, GameObject speakerPrefabGO)
        {
            PrefabUtils.AddBasicComponents(speakerPrefabGO, classID, speakerTechType, LargeWorldEntity.CellLevel.Near);

            float scale = .6f;
            speakerPrefabGO.transform.localScale = new Vector3(scale, scale, scale);

            GameObject model = speakerPrefabGO.transform.Find("SpeakerModel").gameObject;

            Constructable constructable = speakerPrefabGO.EnsureComponent<Constructable>();
            constructable.techType = speakerTechType;
            constructable.model = model;
            constructable.allowedOnWall = true;
            constructable.allowedOnGround = true;
            constructable.allowedInBase = true;
            constructable.allowedInSub = true;
            constructable.allowedUnderwater = true;

            constructable.ghostMaterial = MaterialUtils.GhostMaterial;

            ConstructableFlags flags = ConstructableFlags.Wall | ConstructableFlags.Base | ConstructableFlags.Inside |
            ConstructableFlags.Submarine | ConstructableFlags.Ground | ConstructableFlags.Outside;

            PrefabUtils.AddConstructable(speakerPrefabGO, speakerTechType, flags, model);

            MaterialUtils.ApplySNShaders(model, 4f, 1f, 1f);

            return speakerPrefabGO;
        }
    }
}
