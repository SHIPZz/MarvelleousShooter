using System.Collections.Generic;
using UnityEngine;

namespace Code.ECS.Common.Physics
{
  public interface IPhysicsService
  {
    IEnumerable<GameEntity> RaycastAll(Vector3 worldPosition, Vector3 direction, int layerMask);
    GameEntity Raycast(Vector3 worldPosition, Vector3 direction, int layerMask);
    GameEntity LineCast(Vector3 start, Vector3 end, int layerMask);
    IEnumerable<GameEntity> CircleCast(Vector3 position, float radius, int layerMask);
    int CircleCastNonAlloc(Vector3 position, float radius, int layerMask, GameEntity[] hitBuffer);
    TEntity OverlapSphere<TEntity>(Vector3 worldPosition, float radius, int layerMask) where TEntity : class;
    int OverlapCircle(Vector3 worldPos, float radius, Collider[] hits, int layerMask);
  }
}