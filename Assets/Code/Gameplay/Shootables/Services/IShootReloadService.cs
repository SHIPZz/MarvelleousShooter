using System;
using UniRx;

namespace Code.Gameplay.Shootables.Services
{
    public interface IShootReloadService
    {
        IObservable<Unit> ReloadStartedEvent { get; }
        IObservable<Unit> ReloadStoppedEvent { get; }
        void SendStartEvent();
        void SendStopEvent();
    }
}