using System;
using UniRx;

namespace CodeBase.Gameplay.Shootables.Services
{
    public interface IShootReloadService
    {
        IObservable<Unit> ReloadStartedEvent { get; }
        IObservable<Unit> ReloadStoppedEvent { get; }
        void SendStartEvent();
        void SendStopEvent();
    }
}