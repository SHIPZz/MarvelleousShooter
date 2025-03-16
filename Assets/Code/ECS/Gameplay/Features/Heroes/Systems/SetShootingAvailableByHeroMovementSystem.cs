using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class SetShootingAvailableByHeroMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _guns;

        public SetShootingAvailableByHeroMovementSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,GameMatcher.Alive));

            _guns = game
                .GetGroup(GameMatcher.AllOf(
                        GameMatcher.Shootable, 
                        GameMatcher.HeroGun)
                    .NoneOf(GameMatcher.CanRunAndShoot,GameMatcher.Reloading));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity gun in _guns)
            {
                gun.isShootingAvailable = !hero.isRunning && hero.isWalking || hero.isIdle;
            }
        }
    }
}