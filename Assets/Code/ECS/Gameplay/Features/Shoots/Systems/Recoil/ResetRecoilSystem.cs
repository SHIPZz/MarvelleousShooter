using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public class ResetRecoilSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(32);

        public ResetRecoilSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.HorizontalRecoil,
                GameMatcher.VerticalRecoil,
                GameMatcher.RecoilPatternIndex,
                GameMatcher.Gun)
                .NoneOf(GameMatcher.ShootingContinuously)
            );
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.ReplaceRecoilPatternIndex(0);
                entity.ReplaceHorizontalRecoil(0);
                entity.ReplaceVerticalRecoil(0);
            }
        }
    }
}