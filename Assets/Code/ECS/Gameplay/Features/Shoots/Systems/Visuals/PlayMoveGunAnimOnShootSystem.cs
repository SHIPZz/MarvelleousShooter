using System.Collections.Generic;
using DG.Tweening;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Visuals
{
    public class PlayMoveGunAnimOnShootSystem : ReactiveSystem<GameEntity>
    {
        public PlayMoveGunAnimOnShootSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Shooting.Added());

        protected override bool Filter(GameEntity entity) => entity.isGun
                                                             && entity.isShooting
                                                             && entity.isActive
                                                             && entity.hasMoveRecoilTween
                                                             && entity.hasEffectPlayer;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gun in entities)
            {
                gun.MoveRecoilTween.Restart();
            }
        }
    }
}