using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class DisableHeroMovementAnimActiveOnGunActionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _disableAnimMovementActions;
        private readonly IGroup<GameEntity> _heroes;

        public DisableHeroMovementAnimActiveOnGunActionSystem(GameContext game)
        {
            _disableAnimMovementActions = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ConnectedWithHero, GameMatcher.Active,GameMatcher.Shootable)
                .AnyOf(
                    GameMatcher.Reloading,
                    GameMatcher.Shooting,
                    GameMatcher.ShootingContinuously,
                    GameMatcher.ShootAnimationProcessing,
                    GameMatcher.SwitchingProcessing,
                    GameMatcher.Aiming
                ));

            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                if (_disableAnimMovementActions.count > 0) 
                    hero.isMovementAnimAvailable = false;
            }
        }
    }
}