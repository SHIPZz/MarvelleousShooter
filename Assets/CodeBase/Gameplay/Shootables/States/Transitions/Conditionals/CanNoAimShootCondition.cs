using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;

namespace CodeBase.Gameplay.Shootables.States.Conditionals
{
    public class CanNoAimShootCondition : ICondition
    {
        private readonly IInputService _inputService;
        private readonly IShootService _shootService;
        private readonly IHeroService _heroService;

        public CanNoAimShootCondition(IInputService inputService, IShootService shootService, IHeroService heroService)
        {
            _inputService = inputService;
            _shootService = shootService;
            _heroService = heroService;
        }

        public bool IsMet() => !_inputService.IsAiming() 
                               && _inputService.IsShooting() 
                               && _shootService.IsShootingAvailable 
                               && (!_inputService.IsRunningPressed() || _shootService.CanRunAndShooting);
    }
}