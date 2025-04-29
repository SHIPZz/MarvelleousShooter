using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Visuals
{
    public class PlayRunningSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public PlayRunningSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RunningAvailable,
                    GameMatcher.RunningAnimAvailable,
                    GameMatcher.Running,
                    GameMatcher.AnimancerAnimator,
                    GameMatcher.MovementAnimAvailable));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.AnimancerAnimator.LastPlayingAnimation != AnimationTypeId.Run)
                    entity.AnimancerAnimator.StartAnimation(AnimationTypeId.Run);
            }
        }
    }
}