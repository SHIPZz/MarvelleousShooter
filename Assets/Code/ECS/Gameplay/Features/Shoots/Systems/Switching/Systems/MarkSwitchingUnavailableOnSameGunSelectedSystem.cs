using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class MarkSwitchingUnavailableOnSameGunSelectedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _switchings;
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _shootHolders;

        public MarkSwitchingUnavailableOnSameGunSelectedSystem(GameContext game)
        {
            _game = game;
            _switchings = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Switchable,
                    GameMatcher.ShootSwitchingRequested,
                    GameMatcher.TargetInputGun));

            _shootHolders = game.GetGroup(GameMatcher.AllOf(GameMatcher.ShootHolder,
                GameMatcher.CurrentGunId));
        }

        public void Execute()
        {
            foreach (GameEntity switching in _switchings)
            foreach (GameEntity shootHolder in _shootHolders)
            {
                GameEntity currentShoot = _game.GetEntityWithId(shootHolder.CurrentGunId);

                if (currentShoot.GunInputKey == switching.TargetInputGun)
                {
                    switching.isSameGunSelected = true;
                    switching.isShootSwitchingAvailable = false;
                }
                else
                {
                    switching.isSameGunSelected = false;
                    switching.isShootSwitchingAvailable = true;
                }
            }
        }
    }
}