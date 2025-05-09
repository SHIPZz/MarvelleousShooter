using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class SetNewGunToShootHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _shootHolders;
        private readonly IGroup<GameEntity> _switchings;

        public SetNewGunToShootHolderSystem(GameContext game)
        {
            _shootHolders = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ShootHolder));

            _switchings = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Switchable,
                GameMatcher.TargetSwitchGunId,
                GameMatcher.HidingProcessed));
        }

        public void Execute()
        {
            foreach (GameEntity shootHolder in _shootHolders)
            foreach (GameEntity switching in _switchings)
            {
                shootHolder.ReplaceCurrentGunId(switching.TargetSwitchGunId);
            }
        }
    }
}