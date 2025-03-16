using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class SetHeroRunningAvailableOnAimingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _guns;

        public SetHeroRunningAvailableOnAimingSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.CanRun));

            _guns = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.HeroGun,
                    GameMatcher.Shootable));

        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity gun in _guns)
            {
                hero.isRunningAnimAvailable = !gun.isAiming;
                hero.isRunningAvailable = !gun.isAiming;

                if (gun.isAiming)
                    hero.isRunning = false;
            }
        }
    }
}