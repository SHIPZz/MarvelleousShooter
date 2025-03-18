using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class DisableHeroRunningAnimOnGunActionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _disableRunningActions;
        private readonly IGroup<GameEntity> _heroes;

        public DisableHeroRunningAnimOnGunActionSystem(GameContext game)
        {
            _disableRunningActions = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.HeroGun)
                .AnyOf(
                    GameMatcher.ShootingContinuously,
                    GameMatcher.Reloading,
                    GameMatcher.Aiming
                ));

            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                bool actionsEmpty = _disableRunningActions.GetEntities().Length <= 0;
                
                hero.isRunningAnimAvailable = actionsEmpty;
            }
        }
    }
}