using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace CodeBase.Gameplay.Enemies.AI
{
    public class CooldownAttack : EnemyConditional
    {
        private float _attackCooldown = 1f; 
        private float _lastAttackTime;

        public override void OnStart()
        {
            base.OnStart();
            _lastAttackTime = Time.time; 
        }

        public override TaskStatus OnUpdate()
        {
            if (Time.time - _lastAttackTime < _attackCooldown)
            {
                return TaskStatus.Running;
            }
            
            _lastAttackTime = Time.time;
            
            return TaskStatus.Success;
        }
    }
}