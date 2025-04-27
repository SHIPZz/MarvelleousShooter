using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Visuals
{
    public class MarkShootingAnimationProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkShootingAnimationProcessingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Shootable, GameMatcher.AnimancerAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                AnimancerAnimatorPlayer animator = entity.AnimancerAnimator;
                
                entity.isShootAnimationProcessing =
                    animator.IsPlaying(AnimationTypeId.Shoot) || 
                    animator.IsPlaying(AnimationTypeId.AimShoot);
            }
        }
    }
}