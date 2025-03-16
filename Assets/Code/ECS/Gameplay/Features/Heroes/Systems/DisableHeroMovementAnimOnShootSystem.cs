using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class DisableHeroMovementAnimOnShootSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;
        private readonly IGroup<GameEntity> _heroes;

        public DisableHeroMovementAnimOnShootSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.Hero);

            _guns = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Shootable,
                    GameMatcher.HeroGun
                ));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity gun in _guns)
            {
                if (gun.isShootingRequested && gun.isShootingAvailable)
                    hero.isMovementAnimAvailable = false;
            }
        }
    }
}