using RSG;

namespace Code.ECS.Infrastructure.StateInfrastructure
{
    public class SimpleState : IState
    {
        public virtual void Enter()
        {
      
        }

        protected virtual void Exit()
        {
      
        }

        IPromise IPromiseExitableState.BeginExit()
        {
            Exit();
            return Promise.Resolved();
        }

        void IPromiseExitableState.EndExit()
        {
      
        }
    }
}