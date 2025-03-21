using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems.Visuals
{
    public class SetupHeroGunOnSwitchingSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly GameContext _gameContext;

        public SetupHeroGunOnSwitchingSystem(IContext<GameEntity> game, GameContext gameContext) : base(game)
        {
            _gameContext = gameContext;
            _heroes = game.GetGroup(GameMatcher.Hero);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.ShowingProcessed.Added());

        protected override bool Filter(GameEntity entity) => entity.isSwitchable
                                                             && entity.hasTargetSwitchGunId;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            foreach (GameEntity hero in _heroes)
            {
                GameEntity targetGun = _gameContext.GetEntityWithId(entity.TargetSwitchGunId);

                hero.ReplaceAnimancerAnimator(targetGun.AnimancerAnimator);
            }
        }
    }
}