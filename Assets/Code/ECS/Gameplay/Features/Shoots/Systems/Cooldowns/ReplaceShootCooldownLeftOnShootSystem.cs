using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Cooldowns
{
    public class ReplaceShootCooldownLeftOnShootSystem : ReactiveSystem<GameEntity>
    {
        public ReplaceShootCooldownLeftOnShootSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Shooting.Added());

        protected override bool Filter(GameEntity entity) => entity.isShootable
                                                             && entity.isShooting;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.ReplaceShootCooldownLeft(entity.ShootCooldown);
                entity.isShootCooldownUp = false;
            }
        }
    }
}