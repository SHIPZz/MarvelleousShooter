using CodeBase.Gameplay.Input;

namespace CodeBase.Gameplay.Shootables.States.Conditionals
{
    public class NoMouseButtonInputCondition : ICondition
    {
        private readonly IInputService _inputService;

        public NoMouseButtonInputCondition(IInputService inputService)
        {
            _inputService = inputService;
        }

        public bool IsMet() => !_inputService.IsShooting() || !_inputService.IsAiming();
    }
}