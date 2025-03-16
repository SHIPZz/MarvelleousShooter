using System;
using Code.ECS.Common.Time;
using UniRx;
using Zenject;

namespace Code.Gameplay.Common.Timer
{
    public class TimerService : ITickable, ITimerService
    {
        private readonly ITimeService _timeService;
        
        private readonly Subject<Unit> _executed = new();
        private readonly Subject<float> _timeChanged = new();

        private float _targetTime;
        private float _cachedTargetTime;
        private bool _stopped;

        public IObservable<Unit> Executed => _executed;

        public IObservable<float> TimeChanged => _timeChanged;


        public TimerService(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public void Tick()
        {
            if (_stopped)
                return;

            _targetTime -= _timeService.DeltaTime;

            if (_targetTime <= 0)
            {
                _stopped = true;
                _targetTime = 0;
                _executed?.OnNext(default);
            }

            _timeChanged?.OnNext(_targetTime);
        }

        public void Init(float targetTime)
        {
            _targetTime = targetTime;
            _cachedTargetTime = _targetTime;
        }

        public void Start()
        {
            _targetTime = _cachedTargetTime;
        }

        public void Stop()
        {
            _stopped = true;
            _targetTime = _cachedTargetTime;
            _timeChanged?.OnNext(_targetTime);
        }
    }
}