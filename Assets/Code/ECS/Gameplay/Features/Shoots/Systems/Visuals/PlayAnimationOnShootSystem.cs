using System.Collections.Generic;
using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Visuals
{
    public class PlayAnimationOnShootSystem : ReactiveSystem<GameEntity>
    {
        public PlayAnimationOnShootSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Shooting.Added());

        protected override bool Filter(GameEntity entity) => entity.isShootingContinuously;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.AnimancerAnimator.StartAnimation(AnimationTypeId.Shoot, 0.1f);
            }
        }
    }
}