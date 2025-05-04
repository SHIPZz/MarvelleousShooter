using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class SetTargetRequestedGunOnSwitchingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _shootHolders;
        private readonly IGroup<GameEntity> _guns;

        public SetTargetRequestedGunOnSwitchingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ShootSwitchingRequested,
                    GameMatcher.ShootSwitchingAvailable,
                    GameMatcher.Switchable,
                    GameMatcher.TargetInputGun));
            
            _guns = game.GetGroup(GameMatcher.AllOf(GameMatcher.Shootable,
                GameMatcher.GunInputKey,
                GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                GameEntity targetGun = GetTargetGun(entity);
                
                if(targetGun == null)
                    continue;

                entity.ReplaceTargetSwitchGunId(targetGun.Id);
            }
        }

        private GameEntity GetTargetGun(GameEntity entity)
        {
            GameEntity targetGun = null;

            foreach (GameEntity gun in _guns)
            {
                if (gun.GunInputKey == entity.TargetInputGun)
                    targetGun = gun;
            }

            return targetGun;
        }
    }
}