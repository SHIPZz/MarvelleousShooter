
using Code.InfraStructure.States.StateInfrastructure;

namespace Code.InfraStructure.States.StateMachine
{
    public interface IStateMachine 
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}