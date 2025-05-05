using Code.Gameplay.Common.Services.Raycast;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Collisions.Systems
{
    public class CastForGroundDetectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IRaycastService _raycastService;

        public CastForGroundDetectionSystem(GameContext game, IRaycastService raycastService)
        {
            _raycastService = raycastService;

            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.NeedGroundDetection,
                    GameMatcher.Transform,
                    GameMatcher.WorldPosition,
                    GameMatcher.GroundDetectionTransform,
                    GameMatcher.GroundDetectionMask,
                    GameMatcher.GroundDepth));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                // int hitCount = _raycastService.GetSphereCastTargetHitsNonAlloc(out RaycastHit[] hits,
                //     entity.GroundDetectionTransform.position,
                //     Vector3.down * entity.GroundDepth, entity.GroundRadius, entity.GroundDepth,
                //     entity.GroundDetectionMask);
                //
                // entity.isOnGround = hits[0].collider != null && IsSurfaceWalkable(hits[0].normal,entity.CharacterController.slopeLimit);
            }

            _raycastService.ClearRaycastHits();
        }

        private bool IsSurfaceWalkable(Vector3 normal, float maxAngle)
        {
            float dotProduct = Vector3.Dot(normal, Vector3.up);
    
            return dotProduct > 0 && dotProduct >= Mathf.Cos(maxAngle * Mathf.Deg2Rad);
        }
    }
}