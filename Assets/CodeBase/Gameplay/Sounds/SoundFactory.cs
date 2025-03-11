using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Sounds
{
    public class SoundFactory : ISoundFactory
    {
        private readonly ISoundStaticDataService _effectStaticDataService;
        private readonly IInstantiator _instantiator;

        public SoundFactory(ISoundStaticDataService soundStaticData, IInstantiator instantiator)
        {
            _effectStaticDataService = soundStaticData;
            _instantiator = instantiator;
        }
        
        public Sound Create(SoundTypeId soundTypeId, Transform parent, Vector3 at, Quaternion rotation, bool useOwnPosition = false)
        {
            var prefab = _effectStaticDataService.GetEffect(soundTypeId);

            if (useOwnPosition)
                at = prefab.transform.position;

            return _instantiator.InstantiatePrefabForComponent<Sound>(prefab, at, rotation, parent);
        }
    }
}