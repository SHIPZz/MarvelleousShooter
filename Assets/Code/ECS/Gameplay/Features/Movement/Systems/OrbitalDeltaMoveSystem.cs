using Code.ECS.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class OrbitalDeltaMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;

        public OrbitalDeltaMoveSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.OrbitRadius,
                    GameMatcher.OrbitPhase,
                    GameMatcher.OrbitCenterPosition,
                    GameMatcher.Speed,
                    GameMatcher.MovingAvailable
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                float phase = entity.OrbitPhase + _timeService.DeltaTime * entity.Speed;
                entity.ReplaceOrbitPhase(phase);

                Vector3 newRelativePosition = new Vector3(
                    Mathf.Cos(phase) * entity.OrbitRadius,
                    Mathf.Sin(phase) * entity.OrbitRadius,
                    0
                );

                Vector3 newPosition = newRelativePosition + entity.OrbitCenterPosition;
                entity.ReplaceWorldPosition(newPosition);
            }
        }
    }
}