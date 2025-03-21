using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Visuals
{
    public class SetAnimationFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SetAnimationFinishedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Active,
                GameMatcher.Shootable,
                GameMatcher.ShootingAvailable,
                GameMatcher.NeedAnimationComplete,
                GameMatcher.AnimancerAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (!entity.isAiming && entity.isShooting && !entity.AnimancerAnimator.IsPlaying(AnimationTypeId.Shoot))
                {
                    entity.isShootAnimationFinished = false;
                    continue;
                }

                if (!entity.AnimancerAnimator.IsPlaying(AnimationTypeId.AimShoot))
                    entity.isShootAnimationFinished = true;
            }
        }
    }
}