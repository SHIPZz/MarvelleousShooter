using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class UpdateWorldPositionFromCharacterControllerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public UpdateWorldPositionFromCharacterControllerSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.CharacterController,
                    GameMatcher.WorldPosition
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceWorldPosition(entity.Transform.position);
            }
        }
    }
}