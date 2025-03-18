using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class SetNewGunOnTargetGunShownSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _shootHolders;

        public SetNewGunOnTargetGunShownSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetGunShown,
                    GameMatcher.TargetSwitchGunId
                ));

            _shootHolders = game.GetGroup(GameMatcher.AllOf(GameMatcher.ShootHolder));
        }

        public void Execute()
        {
            foreach (GameEntity shootHolder in _shootHolders)
            foreach (GameEntity entity in _entities)
            {
                shootHolder.ReplaceCurrentGunId(entity.TargetSwitchGunId);
            }
        }
    }
}