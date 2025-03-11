using BehaviorDesigner.Runtime.Tasks;
using CodeBase.Extensions;
using CodeBase.Gameplay.Heroes;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Movement;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Enemies.AI
{
    public class EnemyAction : Action
    {
        [SerializeField] protected Rigidbody Rigidbody;
        [SerializeField] protected Animator Animator;
        [SerializeField] protected Enemy Enemy;
        
        protected Hero Hero;
        protected IMovable Movable;

        [Inject]
        private void Construct(IHeroService heroService)
        {
            Hero = heroService.Hero;
        }

        public override void OnAwake()
        {
            Rigidbody = gameObject.GetComponentAnywhere<Rigidbody>();
            Animator = gameObject.GetComponentAnywhere<Animator>();
            Enemy = gameObject.GetComponentAnywhere<Enemy>();
            Movable = gameObject.GetComponentAnywhere<IMovable>();
        }
    }
}