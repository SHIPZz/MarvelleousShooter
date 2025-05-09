using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Animations.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload.Visuals
{
    public class PlayReloadAnimationSystem : ReactiveSystem<GameEntity>
    {
        public PlayReloadAnimationSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Reloading.Added());

        protected override bool Filter(GameEntity entity) => entity.hasAnimancerAnimator 
                                                             && entity.isActive
                                                             && entity.isReloadable;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.AnimancerAnimator.StartAnimation(AnimationTypeId.Recharge);
            }
        }
    }

}