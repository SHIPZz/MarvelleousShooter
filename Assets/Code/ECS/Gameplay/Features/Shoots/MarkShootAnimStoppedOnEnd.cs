using Code.Gameplay.Animations;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots
{
    public class MarkShootAnimStoppedOnEnd : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkShootAnimStoppedOnEnd(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AnimancerAnimator,GameMatcher.Shootable));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                AnimancerAnimatorPlayer animancer = entity.AnimancerAnimator;
                
                if (animancer.IsPlaying(AnimationTypeId.Shoot) || animancer.IsPlaying(AnimationTypeId.AimShoot))
                {
                    entity.isShootAnimationFinished = false;
                    return;
                }
                
                entity.isShootAnimationFinished = true;
            }
        }
    }
}