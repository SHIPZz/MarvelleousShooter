using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class SetNewGunToGunHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _gunHolders;
        private readonly IGroup<GameEntity> _switchings;

        public SetNewGunToGunHolderSystem(GameContext game)
        {
            _gunHolders = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.GunHolder));

            _switchings = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Switchable,
                GameMatcher.TargetSwitchGunId,
                GameMatcher.HidingProcessed));
        }

        public void Execute()
        {
            foreach (GameEntity gunHolder in _gunHolders)
            foreach (GameEntity switching in _switchings)
            {
                gunHolder.ReplaceCurrentGunId(switching.TargetSwitchGunId);
            }
        }
    }
}