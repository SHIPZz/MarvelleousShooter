using System.Collections.Generic;
using Code.Gameplay.Animations;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems.Visuals
{
    public class ShowTargetGunOnSwitchingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly GameContext _game;
        private readonly List<GameEntity> _buffer = new(2);

        public ShowTargetGunOnSwitchingSystem(GameContext game)
        {
            _game = game;

            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Switching,
                    GameMatcher.TargetSwitchGunId,
                    GameMatcher.PreviousGunHidden
                )
                .NoneOf(
                    GameMatcher.TargetGunShown
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                GameEntity gun = _game.GetEntityWithId(entity.TargetSwitchGunId);

                StartAndMarkAnimationStarted(entity, gun);

                MarkNewGunShown(gun, entity);
            }
        }

        private static void MarkNewGunShown(GameEntity gun, GameEntity entity)
        {
            if (!gun.AnimancerAnimator.IsPlaying(AnimationTypeId.Get) && entity.isShowingStarted)
            {
                entity.isTargetGunShown = true;
                entity.isShowingStarted = false;
            }
        }

        private static void StartAndMarkAnimationStarted(GameEntity entity, GameEntity gun)
        {
            if (!entity.isShowingStarted)
            {
                gun.isViewActive = true;
                gun.AnimancerAnimator.StartAnimation(AnimationTypeId.Get);
                entity.isShowingStarted = true;
            }
        }
    }
}