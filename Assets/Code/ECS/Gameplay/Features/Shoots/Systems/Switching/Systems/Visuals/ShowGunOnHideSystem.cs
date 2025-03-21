using System.Collections.Generic;
using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems.Visuals
{
    public class ShowGunOnHideSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(2);
        private readonly GameContext _game;

        public ShowGunOnHideSystem(GameContext game)
        {
            _game = game;

            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.HidingProcessed)
                .NoneOf(GameMatcher.ShowingProcessed));
        }


        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                GameEntity gun = _game.GetEntityWithId(entity.TargetSwitchGunId);

                ShowAnimation(entity, gun);

                if (TryMarkProcessed(entity, gun))
                    return;

                entity.isShowingProcessing = true;
            }
        }

        private static bool TryMarkProcessed(GameEntity entity, GameEntity gun)
        {
            if (entity.isShowingProcessing && !gun.AnimancerAnimator.IsPlaying(AnimationTypeId.Get))
            {
                entity.isShowingProcessed = true;
                entity.isShowingProcessing = false;
                return true;
            }

            return false;
        }

        private static void ShowAnimation(GameEntity entity, GameEntity gun)
        {
            if (!entity.isShowingProcessing)
            {
                gun.isViewActive = true;
                gun.AnimancerAnimator.StartAnimation(AnimationTypeId.Get, 0.1f);
            }
        }
    }
}