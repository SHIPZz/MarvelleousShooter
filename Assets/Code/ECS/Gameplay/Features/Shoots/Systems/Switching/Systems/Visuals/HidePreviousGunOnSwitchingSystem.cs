using System.Collections.Generic;
using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems.Visuals
{
    public class HidePreviousGunOnSwitchingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly GameContext _game;
        private readonly List<GameEntity> _buffer = new(2);

        public HidePreviousGunOnSwitchingSystem(GameContext game)
        {
            _game = game;

            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Switching,
                    GameMatcher.PreviousSwitchedGunId));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                GameEntity gun = _game.GetEntityWithId(entity.PreviousSwitchedGunId);

                StartAndMarkAnimationStarted(entity, gun);

                MarkGunHidden(entity, gun);
            }
        }

        private static void StartAndMarkAnimationStarted(GameEntity entity, GameEntity gun)
        {
            if (!entity.isHidingStarted)
            {
                gun.AnimancerAnimator.StartAnimation(AnimationTypeId.Hide,0.1f);
                entity.isHidingStarted = true;
            }
        }

        private static void MarkGunHidden(GameEntity entity, GameEntity gun)
        {
            if (entity.isHidingStarted && !gun.AnimancerAnimator.IsPlaying(AnimationTypeId.Hide))
            {
                entity.isPreviousGunHidden = true;
                entity.isHidingStarted = false; 
                gun.isViewActive = false; 
            }
        }
    }
}