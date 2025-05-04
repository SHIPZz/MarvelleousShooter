using UnityEngine;

namespace Code.Gameplay.Common.Services.Raycast
{
    public class RaycastHitService : IRaycastService
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
        
        public int GetTargetHitsNonAlloc(out RaycastHit[] hits, Vector3 origin, Vector3 direction, float distance, LayerMask mask)
        {
            direction = direction.normalized;
    
            Ray ray = new Ray(origin, direction);
            Debug.DrawRay(origin, direction * distance, Color.yellow, 1f);

            int hitCount = Physics.RaycastNonAlloc(ray, _raycastHits, distance, mask);

            System.Array.Sort(_raycastHits, 0, hitCount, new RaycastHitComparer());

            hits = _raycastHits;
            return hitCount;
        }

        
        public int GetSphereCastTargetHitsNonAlloc(out RaycastHit[] hits, Vector3 origin, Vector3 direction, float radius, LayerMask mask)
        {
            Ray ray = new Ray(origin, direction);

            int hitCount = Physics.SphereCastNonAlloc(ray, radius, _raycastHits, mask);

            DrawDebug(origin,radius,1f,Color.yellow);
            
            System.Array.Sort(_raycastHits, 0, hitCount, new RaycastHitComparer());

            hits = _raycastHits;

            return hitCount;
        }
        
        public int GetSphereCastTargetHitsNonAlloc(out RaycastHit[] hits, Vector3 origin, Vector3 direction, float radius, float distance, LayerMask mask)
        {
            direction = direction.normalized;
            Ray ray = new Ray(origin, direction);

            int hitCount = Physics.SphereCastNonAlloc(ray, radius, _raycastHits, distance, mask);

            DrawDebugSphereCast(origin, direction, radius, distance, Color.yellow, 1f);

            System.Array.Sort(_raycastHits, 0, hitCount, new RaycastHitComparer());

            hits = _raycastHits;
            return hitCount;
        }

        
        public void ClearRaycastHits()
        {
            if(_raycastHits.Length <= 0)
                return;
            
            for (int i = 0; i < _raycastHits.Length; i++)
            {
                _raycastHits[i] = default;
            }
        }


        private static void DrawDebugSphereCast(Vector3 origin, Vector3 direction, float radius, float distance, Color color, float duration)
        {
            Vector3 end = origin + direction.normalized * distance;

            // Визуальная "труба", по которой идет сфера
            Debug.DrawRay(origin, direction.normalized * distance, color, duration);

            // Визуализация окружностей в начале и в конце (простым способом)
            DrawCircleXZ(origin, radius, color, duration);
            DrawCircleXZ(end, radius, color, duration);
        }

        private static void DrawCircleXZ(Vector3 center, float radius, Color color, float duration, int segments = 20)
        {
            float angleStep = 360f / segments;
            Vector3 prevPoint = center + new Vector3(Mathf.Cos(0f), 0f, Mathf.Sin(0f)) * radius;

            for (int i = 1; i <= segments; i++)
            {
                float angle = angleStep * i * Mathf.Deg2Rad;
                Vector3 nextPoint = center + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * radius;

                Debug.DrawLine(prevPoint, nextPoint, color, duration);
                prevPoint = nextPoint;
            }
        }


        
        private static void DrawDebug(Vector3 worldPos, float radius, float seconds, Color color)
        {
            Debug.DrawRay(worldPos, radius * Vector3.up, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.down, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.left, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.right, color, seconds);
        }
    }
}