using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Animations.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Visuals
{
    public class PlayRunningSystem : ReactiveSystem<GameEntity>
    {
        public PlayRunningSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Running.Added(),
                GameMatcher.MovementAnimAvailable.Added(),
                GameMatcher.RunningAnimAvailable.Added());

        protected override bool Filter(GameEntity entity) => entity.hasAnimancerAnimator 
                                                             && entity.isMovementAnimAvailable
                                                             && entity.isRunningAvailable
                                                             && entity.isRunningAnimAvailable
                                                             && entity.isRunning
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