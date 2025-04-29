using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class DisableShootingAvailableOnRunningSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _guns;

        public DisableShootingAvailableOnRunningSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.Hero,
                    GameMatcher.Alive,
                    GameMatcher.Running,
                    GameMatcher.Moving));

            _guns = game
                .GetGroup(GameMatcher.AllOf(
                        GameMatcher.Shootable, 
                        GameMatcher.Active,
                        GameMatcher.HeroGun)
                    .NoneOf(
                        GameMatcher.CanRunAndShoot,
                        GameMatcher.Reloading
                        ));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity gun in _guns)
            {
                if (hero.isRunning)
                {
                    gun.isShootingAvailable = false;
                }
            }
        }
    }
}