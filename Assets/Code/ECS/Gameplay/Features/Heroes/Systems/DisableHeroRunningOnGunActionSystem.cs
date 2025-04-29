using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class DisableHeroRunningOnGunActionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _disableRunningActions;
        private readonly IGroup<GameEntity> _heroes;

        public DisableHeroRunningOnGunActionSystem(GameContext game)
        {
            _disableRunningActions = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ConnectedWithHero,GameMatcher.Active)
                .AnyOf(
                    GameMatcher.ShootingContinuously,
                    GameMatcher.Shooting,
                    GameMatcher.Aiming
                ));

            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity disableRunningAction in _disableRunningActions)
            {
                if (hero.isRunning)
                    hero.isRunning = false;

                hero.isRunningAvailable = false;
            }
        }
    }
}