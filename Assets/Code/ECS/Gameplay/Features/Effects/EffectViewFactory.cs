using Code.ECS.Extensions;
using UnityEngine;
using Zenject;

namespace Code.ECS.Gameplay.Features.Effects
{
    public interface IEffectViewFactory
    {
        Effect Create(EffectTypeId effectTypeId, Transform parent, Vector3 at, Quaternion rotation, bool useOwnPosition = false);
    }

    public class EffectViewFactory : IEffectViewFactory
    {
        private readonly IEffectStaticDataService _effectStaticDataService;
        private readonly IInstantiator _instantiator;

        public EffectViewFactory(IEffectStaticDataService effectStaticDataService, IInstantiator instantiator)
        {
            _effectStaticDataService = effectStaticDataService;
            _instantiator = instantiator;
        }
        
        public Effect Create(EffectTypeId effectTypeId, Transform parent, Vector3 at, Quaternion rotation, bool useOwnPosition = false)
        {
           var effect = _effectStaticDataService.GetEffect(effectTypeId);

           if (useOwnPosition)
               at = effect.transform.position;

           return _instantiator.InstantiatePrefabForComponent<Effect>(effect, at, rotation, parent)
               .With(x => x.Play());
        }
   
    }
}