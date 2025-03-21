using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class SetNewGunToShootHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _shootHolders;
        private readonly IGroup<GameEntity> _switchables;

        public SetNewGunToShootHolderSystem(GameContext game)
        {
            _shootHolders = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ShootHolder));

            _switchables = game.GetGroup(GameMatcher.AllOf(GameMatcher.Switchable,
                GameMatcher.TargetSwitchGunId,GameMatcher.ShowingProcessed));
        }

        public void Execute()
        {
            foreach (GameEntity shootHolder in _shootHolders)
            foreach (GameEntity switchable in _switchables)
            {
                shootHolder.ReplaceCurrentGunId(switchable.TargetSwitchGunId);
            }
        }
    }
}