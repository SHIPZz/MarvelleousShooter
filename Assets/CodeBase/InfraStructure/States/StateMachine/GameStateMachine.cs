using CodeBase.InfraStructure.States.Factory;
using CodeBase.InfraStructure.States.StateInfrastructure;

namespace CodeBase.InfraStructure.States.StateMachine
{
    public class GameStateMachine : StateMachine, IGameStateMachine
    {

        public GameStateMachine(IStateFactory stateFactory) : base(stateFactory)
        {
        }
    }
}