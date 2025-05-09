using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Ammo
{
    public class MarkAmmoDecreasedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkAmmoDecreasedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AmmoCount,
                    GameMatcher.AmmoCountLeft
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isAmmoDecreased = entity.AmmoCountLeft < entity.AmmoCount;
            }
        }
    }
}