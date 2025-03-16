using Code.Gameplay.Input;
using Entitas;

namespace Code.ECS.Gameplay.Features.Input
{
    public class EmitReloadInputSystem  : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _input;
        private readonly IInputService _inputService;

        public EmitReloadInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _input = input.GetGroup(InputMatcher.Input);
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