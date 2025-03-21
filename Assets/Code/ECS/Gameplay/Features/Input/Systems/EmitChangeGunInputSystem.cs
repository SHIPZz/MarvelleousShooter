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
        private GunInputTypeId _selectedGunInputId = GunInputTypeId.None;

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
                input.isGunChangePressed = _selectedGunInputId != GunInputTypeId.None;
                
                if(_selectedGunInputId == GunInputTypeId.None)
                    continue;
                
                input.ReplaceSelectedShoot(_selectedGunInputId);
                _selectedGunInputId = GunInputTypeId.None;
            }
        }

        public void Initialize()
        {
            _inputService.OnGunSelected.Subscribe(id => _selectedGunInputId = id).AddTo(_compositeDisposable);
        }
        
        public void TearDown()
        {
            _compositeDisposable?.Dispose();
        }
    }
}