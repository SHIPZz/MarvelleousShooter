using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.States;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;
using CodeBase.InfraStructure.States.StateMachine.Async;
using Cysharp.Threading.Tasks;
using Zenject;

namespace CodeBase.Gameplay.Heroes
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