using System;
using CodeBase.Gameplay.Heroes.Enums;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Configs;
using CodeBase.Gameplay.Shootables.States;
using CodeBase.InfraStructure.States.StateMachine;
using UniRx;
using Zenject;

namespace CodeBase.Gameplay.Shootables.Switcher
{
    public class ShootSwitcherService : IInitializable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly IHeroShootHolderService _heroShootHolderService;
        private readonly IShootStateMachine _shootStateMachine;
        private readonly CompositeDisposable _compositeDisposable = new();

        public ShootSwitcherService(IInputService inputService,
            IHeroShootHolderService heroShootHolderService,
            IShootStateMachine shootStateMachine)
        {
            _inputService = inputService;
            _heroShootHolderService = heroShootHolderService;
            _shootStateMachine = shootStateMachine;
        }

        public void Initialize()
        {
            _inputService.OnShootSelected.Subscribe(ProcessSelectedShoot).AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }

        private void ProcessSelectedShoot(ShootInputTypeId shootInputTypeId)
        {
            if (!_heroShootHolderService.TryGetShoot(shootInputTypeId, out Shoot shoot))
                return;

            if (!_heroShootHolderService.IsAlreadyActive(shoot))
            { 
                _shootStateMachine.Enter<SwitchGunState, Shoot>(shoot);
            }
        }
    }
}