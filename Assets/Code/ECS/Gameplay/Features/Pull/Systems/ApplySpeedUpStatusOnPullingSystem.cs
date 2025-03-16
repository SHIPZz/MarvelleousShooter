using Code.ECS.Gameplay.Features.Statuses;
using Code.ECS.Gameplay.Features.Statuses.Applier;
using Entitas;

namespace Code.ECS.Gameplay.Features.Pull.Systems
{
    public class ApplySpeedUpStatusOnPullingSystem :  IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullings;
        private readonly IStatusApplier _statusApplier;
        private readonly IGroup<GameEntity> _pullTargetHolders;

        public ApplySpeedUpStatusOnPullingSystem(GameContext game,
            IStatusApplier statusApplier)
        {
            _statusApplier = statusApplier;

            _pullings = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Pulling,
                    GameMatcher.Pullable,
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers,
                    GameMatcher.PullProducerId,
                    GameMatcher.Id));

            _pullTargetHolders = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PullTargetHolder,
                    GameMatcher.PullTargetHolderStatuses,
                    GameMatcher.PullTargetList,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity pulling in _pullings)
            foreach (GameEntity pullTargetHolder in _pullTargetHolders)
            {
                if (pulling.PullProducerId == pullTargetHolder.Id)
                {
                    foreach (StatusSetup statusSetup in pullTargetHolder.PullTargetHolderStatuses)
                    {
                        _statusApplier.ApplyStatus(statusSetup, pullTargetHolder.Id, pulling.Id);
                    }
                }
            }
        }
    }
}