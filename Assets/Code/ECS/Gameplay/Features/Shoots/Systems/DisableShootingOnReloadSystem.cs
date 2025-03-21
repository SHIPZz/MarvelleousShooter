using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class DisableShootingOnReloadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;

        public DisableShootingOnReloadSystem(GameContext game)
        {
            _guns = game.GetGroup(GameMatcher.AllOf(GameMatcher.Shootable));
        }

        public void Execute()
        {
            foreach (GameEntity gun in _guns)
            {
                if (gun.isReloading)
                {
                    gun.isShootingAvailable = false;
                    gun.isShootAnimationFinished = true;
                    gun.isShooting = false;
                    return;
                }

                gun.isShootingAvailable = true;
            }
        }
    }
}