using System.Collections.Generic;
using System.Linq;

namespace CodeBase.Gameplay.AbilitySystem.StatSystem.StatModifiers
{
    public class StatService : IStatService
    {
        private readonly List<Stats> _stats = new(32);
        
        public float GetStatValue(StatTypeId statTypeId)
        {
            var targetStat = _stats.FirstOrDefault();

            return targetStat.GetStatValue(statTypeId);
        }
        
        public void Add(Stats stats)
        {
            _stats.Add(stats);
        }
    }
}