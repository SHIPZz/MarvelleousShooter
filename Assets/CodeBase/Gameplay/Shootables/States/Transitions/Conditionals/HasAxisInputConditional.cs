using CodeBase.Gameplay.Input;

namespace CodeBase.Gameplay.Shootables.States.Conditionals
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