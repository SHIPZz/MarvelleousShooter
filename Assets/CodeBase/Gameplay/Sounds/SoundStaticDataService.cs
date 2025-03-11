using System.Collections.Generic;
using System.Linq;
using CodeBase.Constant;
using UnityEngine;

namespace CodeBase.Gameplay.Sounds
{
    public class SoundStaticDataService : ISoundStaticDataService
    {
        private readonly Dictionary<SoundTypeId, Sound> _sounds;

        public SoundStaticDataService()
        {
            _sounds = Resources.LoadAll<Sound>(AssetPath.Sounds)
                .ToDictionary(x => x.SoundTypeId, x => x);
        }

        public Sound GetEffect(SoundTypeId soundTypeId) => _sounds[soundTypeId];
    }
}