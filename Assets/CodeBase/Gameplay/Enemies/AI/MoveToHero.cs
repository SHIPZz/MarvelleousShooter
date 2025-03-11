using BehaviorDesigner.Runtime.Tasks;
using CodeBase.Gameplay.Heroes;
using CodeBase.Gameplay.Heroes.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Enemies.AI
{
    public class MoveToHero : EnemyAction
    {
        private IHeroService _heroService;

        [Inject]
        private void Construct(IHeroService heroService)
        {
            _heroService = heroService;
        }

        public override TaskStatus OnUpdate()
        {
            Movable.Move(_heroService.Hero.transform);

            return Movable.RemainingDistance <= Movable.StopDistance
                ? TaskStatus.Success
                : TaskStatus.Running;
        }

        public override void OnEnd()
        {
            base.OnEnd();

            Movable.StopMovement();
        }
    }
}