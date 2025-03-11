using System;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using UniRx;
using Zenject;

namespace CodeBase.Gameplay.Shootables.States.Conditionals
{
    public class NeedReloadingCondition : ICondition, IInitializable, IDisposable
    {
        private readonly IShootService _shootService;
        private readonly IInputService _inputService;
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly IShootReloadService _shootReloadService;
        
        private bool _reloadRequested;

        public NeedReloadingCondition(
            IShootService shootService,
            IShootReloadService shootReloadService,
            IInputService inputService)
        {
            _shootReloadService = shootReloadService;
            _inputService = inputService;
            _shootService = shootService;
        }

        public bool IsMet() => _reloadRequested ||
                               _shootService.NoAmmo &&
                               !_shootService.IsReloading &&
                               _shootService.Reloadable;

        public void Initialize()
        {
            _inputService
                .OnReloadPressed
                .Subscribe(_ => _reloadRequested = true)
               .AddTo(_compositeDisposable);

            _shootReloadService
                .ReloadStoppedEvent
                .Subscribe(_ => _reloadRequested = false)
                .AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}