using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Animations.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems.Visuals
{
    public class HideGunOnSwitchingStartedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(1);
        private readonly IGroup<GameEntity> _gunHolders;
        private readonly GameContext _game;

        public HideGunOnSwitchingStartedSystem(GameContext game)
        {
            _game = game;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.SwitchingStarted)
                .NoneOf(GameMatcher.HidingProcessed));

            _gunHolders = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.GunHolder, 
                GameMatcher.CurrentGunId));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            foreach (GameEntity gunHolder in _gunHolders)
            {
                GameEntity gun = _game.GetEntityWithId(gunHolder.CurrentGunId);

                ShowAnimation(entity, gun);

                if (TryMarkProcessed(entity, gun))
                    return;
                
                entity.isHidingProcessing = true;
            }
        }

        private static void ShowAnimation(GameEntity entity, GameEntity gun)
        {
            if (!entity.isHidingProcessing)
            {
                gun.AnimancerAnimator.StartAnimation(AnimationTypeId.Hide, 0.1f);
                gun.isActive = false;
            }
        }

        private static bool TryMarkProcessed(GameEntity entity, GameEntity gun)
        {
            if (entity.isHidingProcessing && !gun.AnimancerAnimator.IsPlaying(AnimationTypeId.Hide))
            {
                gun.isViewActive = false;
                    
                entity.isHidingProcessed = true;
                entity.isHidingProcessing = false;
                return true;
            }

            return false;
        }
    }
}