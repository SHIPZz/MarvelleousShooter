using Code.Gameplay.Input;
using Entitas;

namespace Code.ECS.Gameplay.Features.Input.Systems
{
    public class EmitJumpingInputSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _inputs;
        private readonly IInputService _inputService;

        public EmitJumpingInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = input.GetGroup(InputMatcher.Input);
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                input.isJumpingRequested = _inputService.IsJumpButtonPressed();
            }
        }
    }
}