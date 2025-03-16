using System.Collections.Generic;
using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems.Visuals
{
    public class PlayHeroAimShootAnimationSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _heroes;

        public PlayHeroAimShootAnimationSystem(IContext<GameEntity> game) : base(game)
        {
            _heroes = game.GetGroup(GameMatcher.Hero);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Shooting.Added(), GameMatcher.Aiming.Added());

        protected override bool Filter(GameEntity entity) => entity.isAiming
                                                             && entity.isShootingContinuously;

        protected override void Execute(List<GameEntity> guns)
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity gun in guns)
            {
                gun.AnimancerAnimator.StartAnimation(AnimationTypeId.AimShoot);
            }
        }
    }
}