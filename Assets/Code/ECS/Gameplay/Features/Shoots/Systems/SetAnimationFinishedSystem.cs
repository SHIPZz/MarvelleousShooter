using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class SetAnimationFinishedSystem : ReactiveSystem<GameEntity>
    {
        public SetAnimationFinishedSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Shooting.Added());

        protected override bool Filter(GameEntity entity) => entity.isShootable
                                                             && entity.isShooting
                                                             && entity.isNeedAnimationComplete;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.isShootAnimationFinished = false;
            }
        }
    }
}