using System.Collections.Generic;
using System.Linq;
using CodeBase.Constant;
using UnityEngine;

namespace CodeBase.Gameplay.Effects
{
    public interface IEffectStaticDataService
    {
        Effect GetEffect(EffectTypeId effectTypeId);
    }

    public class EffectStaticDataService : IEffectStaticDataService
    {
        private Dictionary<EffectTypeId, Effect> _effects;

        public EffectStaticDataService()
        {
            _effects = Resources.LoadAll<Effect>(AssetPath.Effects)
                .ToDictionary(x => x.EffectTypeId, x => x);
        }

        public Effect GetEffect(EffectTypeId effectTypeId) => _effects[effectTypeId];
    }
}