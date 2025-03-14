using UnityEngine;

namespace Code.Gameplay.Common.Services.Raycast
{
    public class RaycastService : IRaycastService
    {
        private const int MaxHits = 10;
        
        private float _distance = 100f;
        private LayerMask _mask;
        
        private readonly RaycastHit[] _raycastHits = new RaycastHit[MaxHits];
        
        public void Init(float distance, LayerMask mask)
        {
            _distance = distance;
            _mask = mask;
        }

        public Vector3 GetRayDirection(Vector3 origin, Vector3 direction) => 
            new Ray(origin, direction).GetPoint(_distance);

        public int GetTargetHitsNonAlloc(out RaycastHit[] hits, Vector3 origin, Vector3 direction)
        {
            Ray ray = new Ray(origin, direction);

            int hitCount = Physics.RaycastNonAlloc(ray, _raycastHits, _distance, _mask);

            System.Array.Sort(_raycastHits, 0, hitCount, new RaycastHitComparer());

            hits = _raycastHits;

            return hitCount;
        }
        
        public void ClearRaycastHits()
        {
            for (int i = 0; i < _raycastHits.Length; i++)
            {
                _raycastHits[i] = default;
            }
        }
    }
}