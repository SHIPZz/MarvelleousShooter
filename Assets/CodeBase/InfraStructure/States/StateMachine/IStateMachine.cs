using CodeBase.InfraStructure.States.StateInfrastructure;

namespace CodeBase.InfraStructure.States.StateMachine
{
    public interface IStateMachine 
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}