using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Ammo
{
    public class MarkAmmoAvailableSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkAmmoAvailableSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AmmoCount,
                    GameMatcher.AmmoCountLeft));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isAmmoAvailable = entity.AmmoCountLeft > 0;
                
                entity.isAmmoDecreased = entity.AmmoCountLeft < entity.AmmoCount;
            }
        }
    }
}