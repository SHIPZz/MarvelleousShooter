using Code.ECS.Common.Services;
using Entitas;

namespace Code.ECS.Gameplay.Features.Input.Systems
{
    public class EmitShootInputSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _input;
        private readonly IInputService _inputService;

        public EmitShootInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _input = input.GetGroup(InputMatcher.AllOf(InputMatcher.Input));
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            {
                input.isShootingPressed = _inputService.IsShooting() && input.isShootingAvailable;
            }
        }
    }
}