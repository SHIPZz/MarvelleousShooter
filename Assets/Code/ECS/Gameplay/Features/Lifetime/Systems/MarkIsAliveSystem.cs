using Entitas;

namespace Code.ECS.Gameplay.Features.Lifetime
{
    public class MarkIsAliveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkIsAliveSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MaxHp,
                    GameMatcher.CurrentHp
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isAlive = entity.CurrentHp > 0;
            }
        }
    }
}