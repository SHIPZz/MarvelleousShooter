using Code.ECS.Common.Time;
using Code.ECS.Extensions;
using Entitas;
using UnityEngine;

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
                GameMatcher.VerticalVelocity)); 
    }

    public void Execute()
    {
        foreach (GameEntity entity in _entities)
        {
            float deltaTime = _timeService.DeltaTime;

            Vector3 horizontal = entity.Direction * entity.Speed;

            Vector3 finalVelocity = horizontal.SetY(entity.VerticalVelocity) * deltaTime;

            entity.ReplaceFinalVelocity(finalVelocity);
            // entity.CharacterController.Move(finalVelocity);
        }
    }
}