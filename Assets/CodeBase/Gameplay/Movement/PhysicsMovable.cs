using UnityEngine;

namespace CodeBase.Gameplay.Movement
{
    public class PhysicsMovable : MonoBehaviour, IMovable
    {
        public Rigidbody Rigidbody;

        [field: SerializeField] public float StopDistance { get; set; } = 1.5f;
        [field: SerializeField] public float Speed { get; set; } = 5f;
        
        public float RemainingDistance => Vector3.Distance(transform.position, _target.position);

        public bool IsMoving => _isMoving;

        private bool _isMoving;
        private Transform _target;
        private bool _byUpdate;

        private void FixedUpdate()
        {
            if (!_byUpdate || _target == null) 
                return; 

            MoveBySelfUpdateInternal();
        }

        public void MoveBySelfUpdate(Transform target)
        {
            _target = target;
            _byUpdate = true;
            _isMoving = true;
        }

        public void Move(Transform target)
        {
            Rigidbody.MovePosition(Vector3.MoveTowards(transform.position, target.position, Speed * Time.fixedDeltaTime));
        }

        public void StopMovement()
        {
            _isMoving = false;
            _byUpdate = false;
            Rigidbody.linearVelocity = Vector3.zero;
        }

        private void MoveBySelfUpdateInternal()
        {
            if (RemainingDistance <= StopDistance)
            {
                StopMovement();
                return;
            }

            Move(_target);
        }
    }
}