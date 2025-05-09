using Code.ECS.Common.Services;
using Entitas;

namespace Code.ECS.Gameplay.Features.Input.Systems
{
    public class AllowDoubleShootingInputSystem  : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _inputs;
        private readonly IInputService _inputService;

        public AllowDoubleShootingInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = input.GetGroup(InputMatcher
                .AllOf(InputMatcher.Input));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                input.isDoubleShootingAvailable = true;
            }
        }
    }
}