using System.Collections.Generic;
using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Visuals
{
    public class PlayIdleSystem : ReactiveSystem<GameEntity>
    {
        public PlayIdleSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Idle.Added(),
                GameMatcher.IdleAvailable.Added(),
                GameMatcher.MovementAnimAvailable.Added()
                );

        protected override bool Filter(GameEntity entity) => entity.hasAnimancerAnimator 
                                                             && entity.isMovementAnimAvailable
                                                             && entity.isIdle
                                                             && entity.isIdleAvailable
                                                             ;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.AnimancerAnimator.StartAnimation(AnimationTypeId.Idle);
            }
        }
    }
}