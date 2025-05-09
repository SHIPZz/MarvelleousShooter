using System.Collections.Generic;
using Code.Gameplay.Common.Services.Raycast;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class CastOnAnimationEndSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;
        private readonly IRaycastService _raycastService;
        private readonly List<GameEntity> _buffer = new(12);

        public CastOnAnimationEndSystem(GameContext game, IRaycastService raycastService)
        {
            _raycastService = raycastService;

            _guns = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ShootingAvailable,
                    GameMatcher.Gun,
                    GameMatcher.ShootDistance,
                    GameMatcher.CanRaycast,
                    GameMatcher.Hits,
                    GameMatcher.CollectTargetsLayerMask,
                    GameMatcher.OnAnimationEndCastRequested,
                    GameMatcher.OnAnimationEndCast
                ));
        }

        public void Execute()
        {
            foreach (GameEntity gun in _guns.GetEntities(_buffer))
            {
                _raycastService.GetTargetHitsNonAlloc(out RaycastHit[] raycastHits,
                    gun.CastFromTargetTransform.position,
                    gun.CastDirection,
                    gun.ShootDistance,
                    gun.CollectTargetsLayerMask);

                gun.Hits.AddRange(raycastHits);
                
                if (gun.Hits.Count > 0)
                    gun.isHitDetected = true;
                
                gun.isOnAnimationEndCastRequested = false;
            }
        }
    }
}