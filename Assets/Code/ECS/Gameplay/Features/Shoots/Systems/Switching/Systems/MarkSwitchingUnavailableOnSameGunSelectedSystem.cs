using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class MarkSwitchingUnavailableOnSameGunSelectedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private GameContext _game;
        private readonly IGroup<GameEntity> _shootHolders;

        public MarkSwitchingUnavailableOnSameGunSelectedSystem(GameContext game)
        {
            _game = game;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Switchable,GameMatcher.TargetInputGun));
            
            _shootHolders = game.GetGroup(GameMatcher.AllOf(GameMatcher.ShootHolder,
                GameMatcher.CurrentGunId));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (GameEntity shootHolder in _shootHolders)
            {
                GameEntity currentShoot = _game.GetEntityWithId(shootHolder.CurrentGunId);
                
                if (currentShoot.GunInputKey == entity.TargetInputGun)
                {
                    entity.isSameGunSelected = true;
                    entity.isShootSwitchingAvailable = false;
                    return;
                }
                
                entity.isShootSwitchingAvailable = true;
            }
        }
    }
}