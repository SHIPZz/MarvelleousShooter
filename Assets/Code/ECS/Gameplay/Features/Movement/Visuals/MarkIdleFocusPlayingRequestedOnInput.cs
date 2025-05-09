using Code.ECS.Gameplay.Features.Animations.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Visuals
{
    public class MarkIdleFocusPlayingRequestedOnInput : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<InputEntity> _idleFocusRequested;

        public MarkIdleFocusPlayingRequestedOnInput(GameContext game, InputContext input)
        {
           _idleFocusRequested = input
               .GetGroup(InputMatcher
                   .AllOf(InputMatcher.Input,
                       InputMatcher.IdleFocusRequested));
            
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HasIdleFocus,
                    GameMatcher.IdleFocusAvailable,
                    GameMatcher.AnimancerAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (InputEntity idleFocus in _idleFocusRequested)
            {
                entity.AnimancerAnimator.StartAnimation(AnimationTypeId.Idle_Other);
                entity.isIdleFocusRequested = true;
            }
        }
    }
}