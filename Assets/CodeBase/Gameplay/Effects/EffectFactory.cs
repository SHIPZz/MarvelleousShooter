using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Effects
{
    public interface IEffectFactory
    {
        Effect Create(EffectTypeId effectTypeId, Transform parent, Vector3 at, Quaternion rotation, bool useOwnPosition = false);
    }

    public class EffectFactory : IEffectFactory
    {
        private readonly IEffectStaticDataService _effectStaticDataService;
        private readonly IInstantiator _instantiator;

        public EffectFactory(IEffectStaticDataService effectStaticDataService, IInstantiator instantiator)
        {
            _effectStaticDataService = effectStaticDataService;
            _instantiator = instantiator;
        }
        
        public Effect Create(EffectTypeId effectTypeId, Transform parent, Vector3 at, Quaternion rotation, bool useOwnPosition = false)
        {
           var effect = _effectStaticDataService.GetEffect(effectTypeId);

           if (useOwnPosition)
               at = effect.transform.position;

           return _instantiator.InstantiatePrefabForComponent<Effect>(effect, at, rotation, parent);
        }
   
    }
}