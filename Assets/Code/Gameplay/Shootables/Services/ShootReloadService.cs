using System;
using UniRx;

namespace Code.Gameplay.Shootables.Services
{
    public class ShootReloadService : IShootReloadService
    {
        private readonly Subject<Unit> _reloadStartedEvent = new Subject<Unit>();
        private readonly Subject<Unit> _reloadStoppedEvent = new Subject<Unit>();

        public IObservable<Unit> ReloadStartedEvent => _reloadStartedEvent;

        public IObservable<Unit> ReloadStoppedEvent => _reloadStoppedEvent;

        public void SendStartEvent() => _reloadStartedEvent?.OnNext(default);
        
        public void SendStopEvent() => _reloadStoppedEvent?.OnNext(default);
    }
}