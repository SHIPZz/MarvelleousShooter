using UnityEngine;

namespace CodeBase.Gameplay.Movement
{
    public interface IMovable
    {
        public float StopDistance { get; set; }
        public float Speed { get; set; }
        public float RemainingDistance { get;  }
        bool IsMoving { get; }
        void MoveBySelfUpdate(Transform target);
        void StopMovement();
        void Move(Transform target);
    }
}