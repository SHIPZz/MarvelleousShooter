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
                .AllOf(GameMatcher.HeroGun)
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
            {
                bool actionsEmpty = _disableRunningActions.GetEntities().Length <= 0;

                if (hero.isRunning)
                    hero.isRunning = actionsEmpty;

                hero.isRunningAvailable = actionsEmpty;
            }
        }
    }
}