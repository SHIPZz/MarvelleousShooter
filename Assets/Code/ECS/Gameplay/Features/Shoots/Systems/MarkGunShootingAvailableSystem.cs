using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class MarkGunShootingAvailableSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;

        public MarkGunShootingAvailableSystem(GameContext game)
        {
            _guns = game.GetGroup(GameMatcher.AllOf(GameMatcher.Gun, GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (GameEntity gun in _guns)
            {
                gun.isShootingAvailable = true;
            }
        }
    }
}