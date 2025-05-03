using Code.ECS.Common.Time;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class MoveToTargetDirectionByCharacterControllerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;

        public MoveToTargetDirectionByCharacterControllerSystem(GameContext game, ITimeService timeService)
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
                entity.CharacterController.Move(entity.Direction * entity.Speed * _timeService.DeltaTime);
            }
        }
    }
}