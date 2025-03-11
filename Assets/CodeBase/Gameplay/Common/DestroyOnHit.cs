using CodeBase.Gameplay.Observers;
using UnityEngine;

namespace CodeBase.Gameplay.Common
{
    public class DestroyOnHit : MonoBehaviour
    {
        [SerializeField] private CollisionObserver _collisionObserver;
        [SerializeField] private float _time = 1f;

        private void OnEnable()
        {
            _collisionObserver.Entered += Do;
        }

        private void OnDisable()
        {
            _collisionObserver.Entered -= Do;
        }

        private void Do(Collision obj)
        {
            Destroy(gameObject, _time);
        }
    }
}