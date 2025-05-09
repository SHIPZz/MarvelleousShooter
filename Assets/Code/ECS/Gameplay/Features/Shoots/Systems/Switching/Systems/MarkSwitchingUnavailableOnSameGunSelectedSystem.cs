using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class MarkSwitchingUnavailableOnSameGunSelectedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _switchings;
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _gunHolders;

        public MarkSwitchingUnavailableOnSameGunSelectedSystem(GameContext game)
        {
            _game = game;
            _switchings = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Switchable,
                    GameMatcher.GunSwitchingRequested,
                    GameMatcher.RequestedSwitchingGun));

            _gunHolders = game.GetGroup(GameMatcher.AllOf(GameMatcher.GunHolder,
                GameMatcher.CurrentGunId));
        }

        public void Execute()
        {
            foreach (GameEntity switching in _switchings)
            foreach (GameEntity gunHolder in _gunHolders)
            {
                GameEntity currentShoot = _game.GetEntityWithId(gunHolder.CurrentGunId);

                if (currentShoot.GunInputKey == switching.RequestedSwitchingGun)
                {
                    switching.isSameGunSelected = true;
                    switching.isGunSwitchingAvailable = false;
                }
                else
                {
                    switching.isSameGunSelected = false;
                    switching.isGunSwitchingAvailable = true;
                }
            }
        }
    }
}