using Code.Gameplay.Common.Services.Raycast;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class CastRaycastOnShootingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;
        private readonly IRaycastService _raycastService;

        public CastRaycastOnShootingSystem(GameContext game, IRaycastService raycastService)
        {
            _raycastService = raycastService;

            _guns = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ShootingAvailable,
                    GameMatcher.ShootingRequested,
                    GameMatcher.Shooting,
                    GameMatcher.AmmoAvailable,
                    GameMatcher.ShootDistance,
                    GameMatcher.CanRaycast,
                    GameMatcher.Hits,
                    GameMatcher.LayerMask,
                    GameMatcher.Gun
                ).NoneOf(GameMatcher.OnAnimationEndCast));
        }

        public void Execute()
        {
            foreach (GameEntity gun in _guns)
            {
                _raycastService.GetTargetHitsNonAlloc(out RaycastHit[] raycastHits,
                    gun.CastFromTargetTransform.position,
                    gun.CastDirection,
                    gun.ShootDistance,
                    gun.LayerMask);

                gun.Hits.AddRange(raycastHits);

                if (gun.Hits.Count > 0)
                    gun.isHitDetected = true;
            }
        }
    }
}