using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;

namespace CodeBase.Gameplay.Shootables.States.Conditionals
{
    public class CanAimShootCondition : ICondition
    {
        private readonly IInputService _inputService;
        private readonly IShootService _shootService;

        public CanAimShootCondition(IInputService inputService, IShootService shootService)
        {
            _inputService = inputService;
            _shootService = shootService;
        }

        public bool IsMet() => _inputService.IsAiming() && _inputService.IsShooting() && _shootService.CanAim;
    }
}