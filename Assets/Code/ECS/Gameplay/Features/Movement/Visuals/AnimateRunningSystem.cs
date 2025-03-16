using System.Collections.Generic;
using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Visuals
{
    public class AnimateRunningSystem : ReactiveSystem<GameEntity>
    {
        public AnimateRunningSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Running.AddedOrRemoved());

        protected override bool Filter(GameEntity entity) => entity.hasAnimancerAnimator 
                                                             && entity.isRunning
                                                             && entity.isMovementAnimAvailable
                                                             && entity.isRunningAvailable
        ;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.AnimancerAnimator.StartAnimation(AnimationTypeId.Run);
            }
        }
    }
}