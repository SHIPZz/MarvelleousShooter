using RSG;

namespace Code.ECS.Infrastructure.StateInfrastructure
{
    public class EndOfFrameExitState : IState, IUpdateable
    {
        private Promise _exitPromise;
        private bool ExitWasRequested => _exitPromise != null;

        public virtual void Enter()
        {
        }

        public void EndExit()
        {
            ExitOnEndOfFrame();
            ClearExitPromise();
        }

        IPromise IPromiseExitableState.BeginExit()
        {
            _exitPromise = new();

            return _exitPromise;
        }

        void  IUpdateable.Update()
        {
            if (!ExitWasRequested)
                OnUpdate();

            if (ExitWasRequested) 
                ResolveExitPromise();
        }

        protected virtual void ExitOnEndOfFrame()
        {
        }

        protected virtual void OnUpdate()
        {
            
        }

        private void ResolveExitPromise()
        {
            _exitPromise?.Resolve();
        }

        private void ClearExitPromise()
        {
            _exitPromise = null;
        }
    }
}