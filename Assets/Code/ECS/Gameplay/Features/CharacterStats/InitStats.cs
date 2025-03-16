using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.ECS.Gameplay.Features.CharacterStats
{
    public static class InitStats
    {
        public static Dictionary<Stats, float> EmptyStatDictionary()
        {
            return Enum.GetValues(typeof(Stats))
                .Cast<Stats>()
                .Except(new[] { Stats.None })
                .ToDictionary(x => x, _ => 0f);
        }
    }
}