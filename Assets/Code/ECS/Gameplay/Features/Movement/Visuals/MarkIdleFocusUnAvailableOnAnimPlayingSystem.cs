using Code.ECS.Gameplay.Features.Animations.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Visuals
{
    public class MarkIdleFocusUnAvailableOnAnimPlayingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkIdleFocusUnAvailableOnAnimPlayingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HasIdleFocus,
                    GameMatcher.AnimancerAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.AnimancerAnimator.IsPlaying(AnimationTypeId.Idle_Other))
                    entity.isIdleFocusAvailable = false;
                else
                    entity.isIdleFocusRequested = false;
            }
        }
    }
}