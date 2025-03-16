using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class MarkHeroRunningAvailableOnShootSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroGuns;
        private readonly IGroup<GameEntity> _heroes;

        public MarkHeroRunningAvailableOnShootSystem(GameContext game)
        {
            _heroGuns = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Shootable,
                    GameMatcher.HeroGun)
                .NoneOf(GameMatcher.CanRunAndShoot));

            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero,GameMatcher.CanRun));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity heroGun in _heroGuns)
            {
                hero.isRunningAvailable = !heroGun.isShooting;
            }
        }

    }
}