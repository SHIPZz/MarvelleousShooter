using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Animations.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.DoubleShoots.Systems
{
    public class CleanupDoubleShootingOnAnimEndSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(16);

        public CleanupDoubleShootingOnAnimEndSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.DoubleShooting,
                GameMatcher.AnimancerAnimator,
                GameMatcher.Gun));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                if(entity.AnimancerAnimator.IsPlaying(AnimationTypeId.Double_Shot))
                    continue;
                
                entity.isDoubleShootRequested = false;
                entity.isDoubleShooting = false;
            }
        }
    }
}