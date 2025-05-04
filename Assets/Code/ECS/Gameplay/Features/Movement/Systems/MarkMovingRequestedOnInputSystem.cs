using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class MarkMovingRequestedOnInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<InputEntity> _input;

        public MarkMovingRequestedOnInputSystem(GameContext game, InputContext input)
        {
            _input = input.GetGroup(InputMatcher.AllOf(InputMatcher.Input));

            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Movable,GameMatcher.MovingAvailable));
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            foreach (GameEntity entity in _entities)
            {
                entity.isMovingRequested = input.isMovementRequested;
            }
        }
    }
}