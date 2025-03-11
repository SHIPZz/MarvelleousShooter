using System;
using UniRx;

namespace CodeBase.Gameplay.Common.Timer
{
    public interface ITimerService
    {
        IObservable<Unit> Executed { get; }
        IObservable<float> TimeChanged { get; }
        void Init(float targetTime);
        void Start();
        void Stop();
    }
}