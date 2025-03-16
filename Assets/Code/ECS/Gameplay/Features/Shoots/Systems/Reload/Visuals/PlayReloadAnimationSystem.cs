using System.Collections.Generic;
using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload.Visuals
{
    public class PlayReloadAnimationSystem : ReactiveSystem<GameEntity>
    {
        public PlayReloadAnimationSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Reloading.Added());

        protected override bool Filter(GameEntity entity) => entity.hasAnimancerAnimator;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.AnimancerAnimator.StartAnimation(AnimationTypeId.Reload);
            }
        }
    }

}