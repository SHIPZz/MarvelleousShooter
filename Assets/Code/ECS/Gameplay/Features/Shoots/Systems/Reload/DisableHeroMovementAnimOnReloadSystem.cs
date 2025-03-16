using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
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
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity gun in _guns)
            {
                if(gun.isShootingRequested && gun.isShootingAvailable)
                    return;
                
                hero.isMovementAnimAvailable = !gun.isReloading;
            }
        }
    }
}