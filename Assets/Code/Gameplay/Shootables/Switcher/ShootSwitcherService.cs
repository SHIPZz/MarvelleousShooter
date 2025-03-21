using System;
using Code.Gameplay.Heroes.Enums;
using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using Code.InfraStructure.States.StateMachine;
using UniRx;
using Zenject;

namespace Code.Gameplay.Shootables.Switcher
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
            _inputService.OnGunSelected.Subscribe(ProcessSelectedShoot).AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }

        private void ProcessSelectedShoot(GunInputTypeId gunInputTypeId)
        {
            if (!_heroShootHolderService.TryGetShoot(gunInputTypeId, out Shoot shoot))
                return;

            if (!_heroShootHolderService.IsAlreadyActive(shoot))
            { 
                // _shootStateMachine.Enter<SwitchGunState, Shoot>(shoot);
            }
        }
    }
}