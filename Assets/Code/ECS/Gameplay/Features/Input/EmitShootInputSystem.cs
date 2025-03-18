using Code.Gameplay.Input;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Input
{
    public class EmitShootInputSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _input;
        private readonly IInputService _inputService;

        public EmitShootInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _input = input.GetGroup(InputMatcher.AllOf(
                InputMatcher.Input,
                InputMatcher.ShootingAvailable));
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            {
                input.isShootingPressed = _inputService.IsShooting();
            }
        }
    }
}