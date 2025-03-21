using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class MarkPreviousGunNonActiveOnHidingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly GameContext _game;

        public MarkPreviousGunNonActiveOnHidingSystem(GameContext game)
        {
            _game = game;

            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HidingStarted,
                    GameMatcher.Switching,
                    GameMatcher.PreviousSwitchedGunId
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                GameEntity targetGun = _game.GetEntityWithId(entity.PreviousSwitchedGunId);

                targetGun.isShootAnimationFinished = true;
                targetGun.isShooting = false;
                targetGun.isShootingContinuously = false;
                
                targetGun.isActive = false;
            }
        }
    }
}