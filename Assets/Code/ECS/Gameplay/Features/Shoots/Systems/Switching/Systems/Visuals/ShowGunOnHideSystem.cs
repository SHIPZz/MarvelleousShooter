using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Animations.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems.Visuals
{
    public class ShowGunOnHideSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _switchings;
        private readonly List<GameEntity> _buffer = new(2);
        private readonly GameContext _game;

        public ShowGunOnHideSystem(GameContext game)
        {
            _game = game;

            _switchings = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.HidingProcessed)
                .NoneOf(GameMatcher.ShowingProcessed));
        }


        public void Execute()
        {
            foreach (GameEntity switching in _switchings.GetEntities(_buffer))
            {
                GameEntity newGun = _game.GetEntityWithId(switching.TargetSwitchGunId);
                
                ShowAnimation(switching, newGun);

                if (TryMarkProcessed(switching, newGun))
                    return;

                switching.isShowingProcessing = true;
            }
        }

        private static bool TryMarkProcessed(GameEntity switching, GameEntity newGun)
        {
            if (switching.isShowingProcessing && !newGun.AnimancerAnimator.IsPlaying(AnimationTypeId.Get))
            {
                switching.isShowingProcessed = true;
                newGun.isActive = true;
                switching.isShowingProcessing = false;
                return true;
            }

            return false;
        }

        private static void ShowAnimation(GameEntity switching, GameEntity newGun)
        {
            if (!switching.isShowingProcessing)
            {
                newGun.isViewActive = true;
                newGun.AnimancerAnimator.StartAnimation(AnimationTypeId.Get, 0.1f);
            }
        }
    }
}