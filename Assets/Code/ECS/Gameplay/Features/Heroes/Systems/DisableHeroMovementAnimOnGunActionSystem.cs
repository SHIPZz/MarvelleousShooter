using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class DisableHeroMovementAnimOnGunActionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _disableAnimMovementActions;
        private readonly IGroup<GameEntity> _heroes;

        public DisableHeroMovementAnimOnGunActionSystem(GameContext game)
        {
            _disableAnimMovementActions = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ConnectedWithHero,GameMatcher.Active)
                .AnyOf(
                    GameMatcher.Reloading,
                    GameMatcher.Shooting,
                    GameMatcher.ShootAnimationProcessing,
                    GameMatcher.SwitchingProcessing,
                    GameMatcher.Aiming
                ));

            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero, 
                GameMatcher.Id,
                GameMatcher.OnGround));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                hero.isMovementAnimAvailable = _disableAnimMovementActions.GetEntities().Length <= 0;
            }
        }
    }
}