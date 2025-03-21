using System.Collections.Generic;
using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems.Visuals
{
    public class HideGunOnSwitchingStartedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(1);
        private readonly IGroup<GameEntity> _shootHolders;
        private readonly GameContext _game;

        public HideGunOnSwitchingStartedSystem(GameContext game)
        {
            _game = game;
            _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.SwitchingStarted)
                .NoneOf(GameMatcher.HidingProcessed));

            _shootHolders = game.GetGroup(GameMatcher.AllOf(GameMatcher.ShootHolder, 
                GameMatcher.CurrentGunId));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            foreach (GameEntity shootHolder in _shootHolders)
            {
                GameEntity gun = _game.GetEntityWithId(shootHolder.CurrentGunId);
                
                ShowAnimation(entity, gun);

                if (TryMarkProcessed(entity, gun))
                    return;
                
                entity.isHidingProcessing = true;
            }
        }

        private static void ShowAnimation(GameEntity entity, GameEntity gun)
        {
            if (!entity.isHidingProcessing)
                gun.AnimancerAnimator.StartAnimation(AnimationTypeId.Hide, 0.1f);
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