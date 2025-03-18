using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class MarkShootSwitchingUnavailableOnSameGunSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _shootHolders;
        private readonly GameContext _game;

        public MarkShootSwitchingUnavailableOnSameGunSystem(GameContext game)
        {
            _game = game;
            
            _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.TargetSwitchGunId));

            _shootHolders = game.GetGroup(GameMatcher.AllOf(GameMatcher.ShootHolder, GameMatcher.CurrentGunId));
        }

        public void Execute()
        {
            foreach (GameEntity shootHolder in _shootHolders)
            foreach (GameEntity entity in _entities)
            {
                GameEntity currentGun = _game.GetEntityWithId(shootHolder.CurrentGunId);

                entity.isShootSwitchingAvailable = entity.TargetSwitchGunId != currentGun.Id;
            }
        }
    }
}