using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Animations.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.DoubleShoots.Systems.Visuals
{
    public class PlayDoubleShootingAnimSystem : ReactiveSystem<GameEntity>
    {
        public PlayDoubleShootingAnimSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.DoubleShooting.Added());

        protected override bool Filter(GameEntity entity) => entity.isShootable 
                                                             && entity.isDoubleShootingAvailable
                                                             && entity.isActive
                                                             && entity.hasAnimancerAnimator
                                                             ;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.AnimancerAnimator.StartAnimation(AnimationTypeId.Double_Shot);
            }
        }
    }

}