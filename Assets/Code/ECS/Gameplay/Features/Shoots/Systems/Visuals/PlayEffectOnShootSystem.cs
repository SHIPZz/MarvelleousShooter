using System.Collections.Generic;
using DG.Tweening;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Visuals
{
    public class PlayEffectOnShootSystem : ReactiveSystem<GameEntity>
    {
        public PlayEffectOnShootSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Shooting.Added());

        protected override bool Filter(GameEntity entity) => entity.isShootable
                                                             && entity.isShooting
                                                             && entity.isActive
                                                             && entity.hasEffectPlayer;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gun in entities)
            {
                //todo refactor
                gun.Transform.DOKill();

                Sequence recoilSequence = DOTween.Sequence();
                recoilSequence
                    .Append(gun.Transform.DOLocalMoveZ(gun.InitialLocalPosition.z - 0.05f, 0.1f))
                    .Append(gun.Transform.DOLocalMoveZ(gun.InitialLocalPosition.z, 0.1f));
                
                gun.EffectPlayer.Play();
            }
        }
    }
}