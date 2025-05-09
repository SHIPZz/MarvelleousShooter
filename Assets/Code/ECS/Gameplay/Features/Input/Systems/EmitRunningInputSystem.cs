using Code.ECS.Common.Services;
using Entitas;

namespace Code.ECS.Gameplay.Features.Input.Systems
{
    public class EmitRunningInputSystem  : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _input;
        private readonly IInputService _inputService;

        public EmitRunningInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _input = input.GetGroup(InputMatcher.Input);
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            {
                input.isRunningPressed = _inputService.IsRunningPressed();
            }
        }
    }
}