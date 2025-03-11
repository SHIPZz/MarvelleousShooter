using CodeBase.Gameplay.Heroes;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;
using CodeBase.InfraStructure.States.StateMachine.Async;
using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.Shootables.States
{
    public class ShootMovementState : IAsyncState, IUpdateable
    {
        private readonly HeroMovement _heroMovement;
        private readonly Shoot _shoot;
        private readonly IShootStateMachine _shootStateMachine;

        public ShootMovementState(IShootService shootService, IHeroService heroService,
            IShootStateMachine shootStateMachine)
        {
            _shootStateMachine = shootStateMachine;
            _heroMovement = heroService.HeroMovement;
            _shoot = shootService.CurrentShoot;
        }

        public UniTask EnterAsync()
        {
            _shoot.StartShooting();
            _heroMovement.Walk();
            
            return UniTask.CompletedTask;
        }

        public UniTask ExitAsync()
        {
            _shoot.StopShooting();
            _heroMovement.Idle();

            _shootStateMachine.Enter<IdleState>();
            
            return UniTask.CompletedTask;
        }

        public void Update() { }
    }
}