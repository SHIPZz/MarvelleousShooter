using Code.ECS.Common.Time;
using Code.ECS.Extensions;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class ApplyGravityToMovementDirectionSystem : IExecuteSystem
    {
        private float _verticalVelocity;
        
        private float _gravity = -9.81f;
        
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;

        public ApplyGravityToMovementDirectionSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Active,
                    GameMatcher.Speed,
                    GameMatcher.Direction,
                    GameMatcher.CharacterController));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                _verticalVelocity += _gravity * _timeService.DeltaTime;
                
                entity.ReplaceDirection(entity.Direction.SetY(_verticalVelocity));
            }
        }
    }
}