using System.Collections.Generic;
using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Visuals
{
    public class AnimateMovingSystem : ReactiveSystem<GameEntity>
    {
        public AnimateMovingSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Moving.AddedOrRemoved());

        protected override bool Filter(GameEntity entity) => entity.hasAnimancerAnimator 
                                                             && entity.isMovingAvailable
                                                             && !entity.isRunning
                                                             && entity.isMovementAnimAvailable
                                                             && entity.isMoving
                                                             ;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.AnimancerAnimator.StartAnimation(AnimationTypeId.Walk);
            }
        }
    }
}