using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class SetShootingAvailableOnReloadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;

        public SetShootingAvailableOnReloadSystem(GameContext game)
        {
            _guns = game
                .GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Shootable, 
                        GameMatcher.HeroGun));
        }

        public void Execute()
        {
            foreach (GameEntity gun in _guns)
            {
                gun.isShootingAvailable = !gun.isReloading;
            }
        }
    }
}