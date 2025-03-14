using System.Collections.Generic;
using Code.Gameplay.AbilitySystem.StatSystem.StatModifiers;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Code.Gameplay.AbilitySystem.StatSystem
{
    public class Stats : SerializedMonoBehaviour
    {
       [OdinSerialize] private Dictionary<StatTypeId, float> _baseStats = new();
       [OdinSerialize] private Dictionary<StatTypeId, List<StatModifier>> _modifiers = new();

        public float GetStatValue(StatTypeId statType)
        {
            float baseValue = _baseStats.TryGetValue(statType, out var targetStatValue) ? targetStatValue : 0f;
            
            if (_modifiers.TryGetValue(statType, out List<StatModifier> targetModifiers))
            {
                foreach (StatModifier statModifier in targetModifiers)
                {
                    baseValue *= statModifier.Value; 
                }
            }
            return baseValue;
        }

        public void AddBaseStat(StatTypeId statTypeId, float value) => _baseStats[statTypeId] = value;

        public float GetBaseValue(StatTypeId statTypeId)
        {
            return _baseStats[statTypeId];
        }

        public void AddModifier(StatModifier modifier)
        {
            if (!_modifiers.ContainsKey(modifier.StatTypeId))
                _modifiers[modifier.StatTypeId] = new List<StatModifier>();

            _modifiers[modifier.StatTypeId].Add(modifier);
        }

        public void RemoveModifier(StatModifier modifier)
        {
            if (_modifiers.TryGetValue(modifier.StatTypeId, out List<StatModifier> targetModifiers))
            {
                targetModifiers.Remove(modifier);
            }
        }
    }
}