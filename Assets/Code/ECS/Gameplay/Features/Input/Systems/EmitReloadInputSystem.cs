﻿using Code.ECS.Common.Services;
using Entitas;

namespace Code.ECS.Gameplay.Features.Input.Systems
{
    public class EmitReloadInputSystem  : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _input;
        private readonly IInputService _inputService;

        public EmitReloadInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _input = input.GetGroup(InputMatcher.AllOf(InputMatcher.Input,InputMatcher.ReloadAvailable));
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            {
                input.isReloadingPressed = _inputService.ReloadPressed;
            }
        }
    }
}