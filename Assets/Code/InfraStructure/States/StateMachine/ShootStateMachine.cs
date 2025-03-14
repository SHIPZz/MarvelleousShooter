using Code.InfraStructure.States.Factory;

namespace Code.InfraStructure.States.StateMachine
{
    public class ShootStateMachine : StateMachine, IShootStateMachine
    {
        public ShootStateMachine(IStateFactory stateFactory) : base(stateFactory) { }
    }
}