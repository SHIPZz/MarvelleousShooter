using BehaviorDesigner.Runtime.Tasks;
using Code.Gameplay.Heroes.Services;
using Zenject;

namespace Code.Gameplay.Enemies.AI
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
            // Movable.Move(_heroService.LoadHero().transform);

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