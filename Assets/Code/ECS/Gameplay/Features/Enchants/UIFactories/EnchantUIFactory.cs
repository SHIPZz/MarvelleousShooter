using Code.ECS.Gameplay.Features.Enchants.Behaviours;
using Code.InfraStructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.ECS.Gameplay.Features.Enchants.UIFactories
{
    public class EnchantUIFactory : IEnchantUIFactory
    {
        // private const string EnchantPrefabPath = "UI/Enchants/Enchant";
        // private IStaticDataService _staticDataService;
        // private IInstantiator _instantiator;
        // private IAssetProvider _assetProvider;
        //
        // public EnchantUIFactory(IInstantiator instantiator, IAssetProvider assetProvider, IStaticDataService staticDataService)
        // {
        //     _assetProvider = assetProvider;
        //     _instantiator = instantiator;
        //     _staticDataService = staticDataService;
        // }

        public Enchant CreateEnchant(Transform parent, EnchantTypeId enchantTypeId)
        {
            return null;
            //  EnchantConfig enchantConfig = _staticDataService.GetEnchantConfig(enchantTypeId);
            //  Enchant enchantPrefab = _assetProvider.LoadAsset<Enchant>(EnchantPrefabPath);
            //
            // return  _instantiator.InstantiatePrefabForComponent<Enchant>(enchantPrefab, parent)
            //     .With(x => x.Set(enchantConfig));
        }
    }
}