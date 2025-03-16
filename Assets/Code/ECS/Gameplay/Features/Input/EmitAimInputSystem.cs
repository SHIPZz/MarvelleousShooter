using Code.Gameplay.Input;
using Entitas;

namespace Code.ECS.Gameplay.Features.Input
{
    public class EmitAimInputSystem  : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _input;
        private readonly IInputService _inputService;

        public EmitAimInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _input = input.GetGroup(InputMatcher.Input);
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            {
                input.isAimingPressed = _inputService.IsAiming();
            }
        }
    }
}