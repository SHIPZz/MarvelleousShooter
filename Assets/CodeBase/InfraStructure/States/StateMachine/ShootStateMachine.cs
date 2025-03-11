using CodeBase.InfraStructure.States.Factory;
using CodeBase.InfraStructure.States.StateMachine.Async;
using Zenject;

namespace CodeBase.InfraStructure.States.StateMachine
{
    public class ShootStateMachine : StateMachine, IShootStateMachine
    {
        public ShootStateMachine(IStateFactory stateFactory) : base(stateFactory) { }
    }
}