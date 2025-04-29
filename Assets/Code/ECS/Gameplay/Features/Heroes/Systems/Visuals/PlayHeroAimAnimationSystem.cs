using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems.Visuals
{
    public class PlayHeroAimAnimationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _guns;

        public PlayHeroAimAnimationSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.Hero);

            _guns = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.HeroGun, 
                GameMatcher.Aiming)
                .NoneOf(GameMatcher.ShootingContinuously));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity gun in _guns)
            {
                if (hero.isWalking && !hero.isRunning)
                    gun.AnimancerAnimator.StartAnimation(AnimationTypeId.AimWalk);
                else
                    gun.AnimancerAnimator.StartAnimation(AnimationTypeId.AimIdle);
            }
        }
    }
}