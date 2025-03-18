using System;
using Code.Gameplay.Heroes.Enums;
using Code.Gameplay.Input;
using Entitas;
using UniRx;

namespace Code.ECS.Gameplay.Features.Input
{
    public class EmitChangeGunInputSystem : IExecuteSystem, IInitializeSystem, ITearDownSystem
    {
        private readonly IGroup<InputEntity> _input;
        private readonly IInputService _inputService;
        private ShootInputTypeId _selectedShootInputId = ShootInputTypeId.None;

        private readonly CompositeDisposable _compositeDisposable = new();
        
        public EmitChangeGunInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _input = input.GetGroup(InputMatcher.Input);
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            {
                input.isGunChangePressed = _selectedShootInputId != ShootInputTypeId.None;
                
                if(_selectedShootInputId == ShootInputTypeId.None)
                    continue;
                
                input.ReplaceSelectedShoot(_selectedShootInputId);
                _selectedShootInputId = ShootInputTypeId.None;
            }
        }

        public void Initialize()
        {
            _inputService.OnShootSelected.Subscribe(id => _selectedShootInputId = id).AddTo(_compositeDisposable);
        }
        
        public void TearDown()
        {
            _compositeDisposable?.Dispose();
        }
    }
}