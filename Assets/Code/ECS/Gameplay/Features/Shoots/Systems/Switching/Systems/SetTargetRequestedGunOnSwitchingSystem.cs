using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Shoots.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class SetTargetRequestedGunOnSwitchingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _gunHolders;
        private readonly IGroup<GameEntity> _guns;
        private readonly List<GameEntity> _buffer = new(3);

        public SetTargetRequestedGunOnSwitchingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.GunSwitchingRequested,
                    GameMatcher.GunSwitchingAvailable,
                    GameMatcher.Switchable,
                    GameMatcher.RequestedSwitchingGun));

            _guns = game.GetGroup(GameMatcher.AllOf(GameMatcher.Gun,
                GameMatcher.GunInputKey,
                GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                GameEntity targetGun = GetTargetGun(entity);

                if (targetGun == null)
                {
                    entity.isGunSwitchingAvailable = false;
                    continue;
                }

                entity.ReplaceTargetSwitchGunId(targetGun.Id);
            }
        }

        private GameEntity GetTargetGun(GameEntity switching)
        {
            return
                GetGunByInput(switching.RequestedSwitchingGun);
        }

        private GameEntity GetGunByInput(GunInputTypeId gunInputType)
        {
            GameEntity targetGun = null;

            foreach (GameEntity gun in _guns)
            {
                if (gun.GunInputKey == gunInputType)
                    targetGun = gun;
            }

            return targetGun;
        }
    }
}