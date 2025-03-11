using CodeBase.InfraStructure.States.Factory;
using CodeBase.InfraStructure.States.StateMachine.Async;

namespace CodeBase.InfraStructure.States.StateMachine
{
    public class HeroStateMachine : AsyncStateMachine, IHeroStateMachine
    {
        public HeroStateMachine(IStateFactory stateFactory) : base(stateFactory) { }
    }
}