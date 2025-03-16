using System.Collections.Generic;
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
                    GameMatcher.RestoreHp
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.ReplaceCurrentHp(entity.CurrentHp + entity.RestoreHp);
                entity.isHpRestored = true;
            }
        }
    }
}