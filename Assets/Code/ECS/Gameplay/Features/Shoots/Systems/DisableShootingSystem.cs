using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class DisableShootingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;

        public DisableShootingSystem(GameContext game)
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
                    return;
                }

                gun.isShootingAvailable = true;
            }
        }
    }
}