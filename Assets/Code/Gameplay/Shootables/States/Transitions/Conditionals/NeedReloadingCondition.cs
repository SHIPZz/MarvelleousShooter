using System;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;
using UniRx;
using Zenject;

namespace Code.Gameplay.Shootables.States.Transitions.Conditionals
{
    public class NeedReloadingCondition : ICondition, IInitializable, IDisposable
    {
        private readonly IShootService _shootService;
        private readonly IInputService _inputService;
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly IShootReloadService _shootReloadService;
        
        private bool _reloadRequested;
        private GameContext _game;

        public NeedReloadingCondition(
            IShootService shootService,
            IShootReloadService shootReloadService,
            IInputService inputService, GameContext game)
        {
            _shootReloadService = shootReloadService;
            _inputService = inputService;
            _game = game;
            _shootService = shootService;
        }

        public bool IsMet()
        {
            foreach (GameEntity shootable in _game.GetGroup(GameMatcher.Shootable))
            {
                return shootable.isReloadable && !shootable.isReloading && !shootable.isAmmoAvailable;
            }

            return false;
            // return _reloadRequested ||
            //        _shootService.NoAmmo &&
            //        !_shootService.IsReloading &&
            //        _shootService.Reloadable;
        }

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