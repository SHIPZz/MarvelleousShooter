using Code.Gameplay.Input;
using Entitas;

namespace Code.ECS.Gameplay.Features.Input.Systems
{
    public class EmitAxisInputSystem  : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _input;
        private readonly IInputService _inputService;

        public EmitAxisInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _input = input.GetGroup(InputMatcher.Input);
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            {
                input.isHasAxis = _inputService.HasAxisInput();
                
                input.ReplaceAxis(_inputService.GetAxis());
            }
        }
    }
}