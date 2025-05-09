using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Ammo
{
    public class CalculateAmmoCountOnShootSystem : ReactiveSystem<GameEntity>
    {
        public CalculateAmmoCountOnShootSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Shooting.Added());

        protected override bool Filter(GameEntity entity) => entity.isGun
                                                             && entity.hasAmmoCount;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.ReplaceAmmoCountLeft(entity.AmmoCountLeft - 1);

                if (entity.AmmoCountLeft <= 0)
                {
                    entity.ReplaceAmmoCountLeft(0);
                    entity.isAmmoAvailable = false;
                }
            }
        }
    }
}