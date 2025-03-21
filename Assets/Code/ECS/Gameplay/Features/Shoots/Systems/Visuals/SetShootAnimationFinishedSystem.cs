using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Visuals
{
    public class SetShootAnimationFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SetShootAnimationFinishedSystem(GameContext game)
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
                if (entity.isAiming)
                {
                    entity.isShootAnimationFinished = !entity.AnimancerAnimator.IsPlaying(AnimationTypeId.AimShoot);
                }
                else if (entity.isShooting)
                {
                    entity.isShootAnimationFinished = !entity.AnimancerAnimator.IsPlaying(AnimationTypeId.Shoot);
                }
                else
                {
                    entity.isShootAnimationFinished = true;
                }
            }
        }
    }
}