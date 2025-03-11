using UnityEngine;

namespace CodeBase.Gameplay.Movement
{
    public class NavMeshMovable : MonoBehaviour, IMovable
    {
        [SerializeField] private UnityEngine.AI.NavMeshAgent _navMeshAgent;
        [field: SerializeField] public float StopDistance { get; set; } = 1.5f;
        [field: SerializeField] public float Speed { get; set; } = 5f;
        
        private bool _byUpdate;
        private Transform _target;
        
        public float RemainingDistance => _navMeshAgent.remainingDistance == 0 ? float.MaxValue : _navMeshAgent.remainingDistance;
        public bool IsMoving => _navMeshAgent.velocity.magnitude > 0.1f;

        private void Awake()
        {
            if (_navMeshAgent == null)
                _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

            _navMeshAgent.stoppingDistance = StopDistance;
            _navMeshAgent.speed = Speed;
        }

        private void Update()
        {
            if (!_byUpdate || _target == null) 
                return; 

            Move(_target);
        }

        public void MoveBySelfUpdate(Transform target)
        {
            _target = target;
            
            if (target == null)
                return;

            _navMeshAgent.SetDestination(target.position);
            _navMeshAgent.isStopped = false;
        }

        public void StopMovement()
        {
            _navMeshAgent.isStopped = true;
            _navMeshAgent.velocity = Vector3.zero;
        }

        public void Move(Transform target)
        {
            if (target == null)
                return;

            _navMeshAgent.SetDestination(target.position);
            _navMeshAgent.isStopped = false;

            if (RemainingDistance <= StopDistance) 
                StopMovement();
        }
    }
}