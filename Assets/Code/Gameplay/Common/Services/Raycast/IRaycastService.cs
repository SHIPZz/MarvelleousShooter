using UnityEngine;

namespace Code.Gameplay.Common.Services.Raycast
{
    public interface IRaycastService
    {
        void Init(float distance, LayerMask mask);
        Vector3 GetRayDirection(Vector3 origin, Vector3 direction);
        int GetTargetHitsNonAlloc(out RaycastHit[] hits, Vector3 origin, Vector3 direction);
        void ClearRaycastHits();
    }
}