using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class AllowShootAvailableSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;

        public AllowShootAvailableSystem(GameContext game)
        {
            _guns = game.GetGroup(GameMatcher.AllOf(GameMatcher.Shootable, GameMatcher.Active));
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