using Code.ECS.Common.Physics;
using Entitas;

namespace Code.ECS.Gameplay.Features.Pull.Systems
{
    public class CastInPullRadiusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullingDetectors;
        private readonly IPhysicsService _physicsService;
        private readonly GameEntity[] _hitBuffer = new GameEntity[128];

        public CastInPullRadiusSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;

            _pullingDetectors = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.PullTargetLayerMask,
                    GameMatcher.PullTargetList,
                    GameMatcher.PullingDetector,
                    GameMatcher.PullInRadius
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _pullingDetectors)
            {
                for (int i = 0; i < TargetInRadius(entity); i++)
                {
                    _hitBuffer[i].isPullable = true;
                    _hitBuffer[i].ReplacePullProducerId(entity.Id);
                }

                ClearBuffer();
            }
        }

        private void ClearBuffer()
        {
            for (int i = 0; i < _hitBuffer.Length; i++)
            {
                _hitBuffer[i] = null;
            }
        }

        private int TargetInRadius(GameEntity entity)
        {
            return _physicsService.CircleCastNonAlloc(entity.WorldPosition, entity.PullInRadius,
                entity.PullTargetLayerMask,
                _hitBuffer);
        }
    }
}