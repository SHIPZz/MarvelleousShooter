using System.Collections.Generic;
using Code.Gameplay.Heroes.Enums;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Code.Gameplay.Shootables.Configs
{
    [CreateAssetMenu(fileName = "ShootConfigs", menuName = "Gameplay/ShootConfigs")]
    public class ShootConfigs : SerializedScriptableObject
    {
        [OdinSerialize] private Dictionary<ShootTypeId, ShootConfig> _shootConfigs;
        
        private Dictionary<ShootInputTypeId, ShootConfig> _shootConfigsByKey = new();

        public ShootConfig GetById(ShootTypeId shootTypeId) => _shootConfigs[shootTypeId];

        public ShootConfig GetByKey(ShootInputTypeId pressedKey) => _shootConfigsByKey.GetValueOrDefault(pressedKey);

        [Button]
        private void FillShootConfigsByKey()
        {
            foreach (ShootConfig shootConfig in _shootConfigs.Values)
            {
                _shootConfigsByKey[shootConfig.ShowKey] = shootConfig;
            }
        }
    }
}
