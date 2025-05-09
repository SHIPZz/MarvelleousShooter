using Code.ECS.Common.Services;
using Entitas;

namespace Code.ECS.Gameplay.Features.Input.Systems
{
    public class EmitDoubleShootingInputSystem  : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _inputs;
        private readonly IInputService _inputService;

        public EmitDoubleShootingInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = input.GetGroup(InputMatcher
                .AllOf(InputMatcher.Input,
                    InputMatcher.DoubleShootingAvailable));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                input.isDoubleShootingRequested = _inputService.IsDoubleShooting();
            }
        }
    }
}