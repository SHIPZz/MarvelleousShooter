using System;
using Code.Gameplay.Shootables.Services;
using UniRx;
using Zenject;

namespace Code.Gameplay.Shootables.States.Transitions.Conditionals
{
    public class HasIdleFocusCondition : ICondition, IInitializable, IDisposable
    {
        private readonly IShootService _shootService;
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly IShootFocusService _shootFocusService;

        private bool _focusRequested;

        public HasIdleFocusCondition(IShootService shootService, IShootFocusService shootFocusService)
        {
            _shootFocusService = shootFocusService;
            _shootService = shootService;
        }

        public void Initialize()
        {
            _shootFocusService
                .Started
                .Subscribe(_ => _focusRequested = true)
                .AddTo(_compositeDisposable);
            
            _shootFocusService
                .Stopped
                .Subscribe(_ => _focusRequested = false)
                .AddTo(_compositeDisposable);
            
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }

        public bool IsMet()
        {
            return _shootFocusService.IsFocusing && _shootFocusService.CurrentGunHasFocus() 
                   || _focusRequested && _shootFocusService.CurrentGunHasFocus();
        }
    }
}