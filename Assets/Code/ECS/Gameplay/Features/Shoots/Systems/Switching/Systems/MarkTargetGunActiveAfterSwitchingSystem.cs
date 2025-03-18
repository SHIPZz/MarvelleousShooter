using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class MarkTargetGunActiveAfterSwitchingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly GameContext _game;

        public MarkTargetGunActiveAfterSwitchingSystem(GameContext game)
        {
            _game = game;

            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetGunShown,
                    GameMatcher.Switching,
                    GameMatcher.TargetSwitchGunId
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                GameEntity targetGun = _game.GetEntityWithId(entity.TargetSwitchGunId);

                targetGun.isActive = true;
            }
        }
    }
}