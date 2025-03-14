using Code.Gameplay.Input;

namespace Code.Gameplay.Shootables.States.Transitions.Conditionals
{
    public sealed class HasAxisInputConditional : ICondition
    {
        private readonly IInputService _inputService;

        public HasAxisInputConditional(IInputService inputService)
        {
            _inputService = inputService;
        }

        public bool IsMet()
        {
           return _inputService.HasAxisInput();
        }
    }
}