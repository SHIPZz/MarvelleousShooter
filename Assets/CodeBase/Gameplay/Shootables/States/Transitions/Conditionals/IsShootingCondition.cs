using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;

namespace CodeBase.Gameplay.Shootables.States.Conditionals
{
    public class IsShootingCondition : ICondition
    {
        private readonly IInputService _inputService;
        private readonly IShootService _shootService;

        public IsShootingCondition(IInputService inputService, IShootService shootService)
        {
            _inputService = inputService;
            _shootService = shootService;
        }

        public bool IsMet()
        {
            return _inputService.IsShooting() && _shootService.IsShootingAvailable;
        }
    }
}