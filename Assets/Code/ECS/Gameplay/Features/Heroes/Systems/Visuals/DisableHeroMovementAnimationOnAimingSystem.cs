using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class DisableHeroMovementAnimationOnAimingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _aimingGuns;
        private readonly IGroup<GameEntity> _heroes;

        public DisableHeroMovementAnimationOnAimingSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.Hero);

            _aimingGuns = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HeroGun,
                    GameMatcher.Aimable,
                    GameMatcher.Shootable));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity gun in _aimingGuns)
            {
                hero.isMovementAnimAvailable = !gun.isAiming && !gun.isShootingContinuously;
            }
        }
    }
}