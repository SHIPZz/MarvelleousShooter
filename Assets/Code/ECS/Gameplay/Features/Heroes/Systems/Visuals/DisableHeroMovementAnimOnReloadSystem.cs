using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class DisableHeroMovementAnimOnReloadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;
        private readonly IGroup<GameEntity> _heroes;

        public DisableHeroMovementAnimOnReloadSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.Hero);
            
            _guns = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Reloadable, 
                    GameMatcher.HeroGun 
                    ).NoneOf(GameMatcher.Aiming));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity gun in _guns)
            {
                if(gun.isShootingContinuously)
                    return;
                
                hero.isMovementAnimAvailable = !gun.isReloading;
            }
        }
    }
}