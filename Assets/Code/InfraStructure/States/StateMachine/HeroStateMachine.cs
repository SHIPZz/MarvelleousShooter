using Code.InfraStructure.States.Factory;
using Code.InfraStructure.States.StateMachine.Async;

namespace Code.InfraStructure.States.StateMachine
{
    public class HeroStateMachine : AsyncStateMachine, IHeroStateMachine
    {
        public HeroStateMachine(IStateFactory stateFactory) : base(stateFactory) { }
    }
}