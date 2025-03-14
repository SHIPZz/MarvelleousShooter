using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.States;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine;
using Code.InfraStructure.States.StateMachine.Async;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Code.Gameplay.Heroes
{
    public class HeroInitState : IAsyncState, IUpdateable
    {
        [Inject] private IShootStateMachine _shootStateMachine;
        [Inject] private IInputService _inputService;
        [Inject] private IShootService _shootService;

        public UniTask EnterAsync()
        {
            _shootStateMachine.Enter<IdleState>();
            return UniTask.CompletedTask;
        }

        public UniTask ExitAsync()
        {
            return UniTask.CompletedTask;
        }

        public void Update()
        {
            
        }
    }
}