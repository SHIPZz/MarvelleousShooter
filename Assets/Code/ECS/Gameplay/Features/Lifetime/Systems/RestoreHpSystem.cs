using System.Collections.Generic;
using Code.ECS.Gameplay.Features.CharacterStats;
using Entitas;

namespace Code.ECS.Gameplay.Features.Lifetime
{
    public class RestoreHpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(128);

        public RestoreHpSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CurrentHp,
                    GameMatcher.StatModifiers,
                    GameMatcher.BaseStats,
                    GameMatcher.RestoreHp
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.StatModifiers[Stats.Hp] += entity.RestoreHp;
                entity.isHpRestored = true;
            }
        }
    }
}