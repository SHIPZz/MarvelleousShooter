using Entitas;

namespace Code.ECS.Gameplay.Features.Pull.Systems
{
    public class MarkTargetPullableOnHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullingDetectors;
        private readonly GameContext _game;

        public MarkTargetPullableOnHitSystem(GameContext game)
        {
            _game = game;
            
            _pullingDetectors = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.Id,
                    GameMatcher.PullAnchorTargetId,
                    GameMatcher.PullingDetector
                ));
        }

        public void Execute()
        {
            foreach (GameEntity pullingDetector in _pullingDetectors)
            foreach (int targetId in pullingDetector.TargetsBuffer)
            {
                GameEntity target = _game.GetEntityWithId(targetId);

                if(target.isDead || target.isPullTargetHolder)
                    continue;

                target.isPullable = true;
                target.ReplacePullProducerId(pullingDetector.PullAnchorTargetId);
            }
        }
    }
}