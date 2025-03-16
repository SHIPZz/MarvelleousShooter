using Code.Gameplay.Cameras;
using Code.Gameplay.Common.Services.Raycast;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class CastRaycastOnShootingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IShootRaycastService _raycastService;
        private readonly ICameraProvider _cameraProvider;

        public CastRaycastOnShootingSystem(GameContext game, IShootRaycastService raycastService, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _raycastService = raycastService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ShootingReady,
                    GameMatcher.ShootingAvailable,
                    GameMatcher.ShootingRequested,
                    GameMatcher.Shooting,
                    GameMatcher.AmmoAvailable,
                    GameMatcher.ShootDistance,
                    GameMatcher.Hits,
                    GameMatcher.LayerMask,
                    GameMatcher.Shootable
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                Vector3 direction = _cameraProvider.Camera.transform.forward;
                Vector3 origin = _cameraProvider.Camera.transform.position;

                _raycastService.GetTargetHitsNonAlloc(out RaycastHit[] raycastHits,
                    origin,
                    direction, 
                    entity.ShootDistance,
                    entity.LayerMask);
                
                entity.ReplaceHits(raycastHits);
            }
        }
    }
}