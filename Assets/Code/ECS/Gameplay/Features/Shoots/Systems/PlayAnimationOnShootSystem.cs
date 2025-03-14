using System.Collections.Generic;
using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class PlayAnimationOnShootSystem : ReactiveSystem<GameEntity>
    {
        public PlayAnimationOnShootSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Shooting.Added());

        protected override bool Filter(GameEntity entity) => entity.isShootable
                                                             && entity.isShooting
                                                             && entity.hasAnimancerAnimator;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                if (!entity.isAiming)
                    entity.AnimancerAnimator.StartAnimation(AnimationTypeId.Shoot);
                else
                    entity.AnimancerAnimator.StartAnimation(AnimationTypeId.AimShoot);
            }
        }
    }
}