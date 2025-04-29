using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class DisableShootingOnReloadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;

        public DisableShootingOnReloadSystem(GameContext game)
        {
            _guns = game.GetGroup(GameMatcher.AllOf(GameMatcher.Shootable, GameMatcher.Reloading, GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (GameEntity gun in _guns)
            {
                gun.isShootingAvailable = false;
                gun.isShooting = false;
            }
        }
    }
}