using System;

namespace Code.ECS.Gameplay.Features.Movement.Configs
{
    [Serializable]
    public class MovementData
    {
        public float Speed;
        public float RunningSpeed = 12;
        public float JumpForce = 6;
        public float AirSpeed = 8;
        
        public float IdleJumpMultiplier = 1;
        public float WalkJumpMultiplier = 1.5f;
        public float RunJumpMultiplier = 2f;
        public float Gravity = -50f;
        public float Damping = -20f;
    }
}