using Code.Gameplay.Shootables.Services;

namespace Code.Gameplay.Shootables.States.Transitions.Conditionals
{
    public class CanReloadCondition : ICondition
    {
        private readonly IShootService _shootService;

        public CanReloadCondition(IShootService shootService)
        {
            _shootService = shootService;
        }

        public bool IsMet() => _shootService.Reloadable &&
                               !_shootService.SameAmmoCount &&
                               !_shootService.IsReloading;
    }
}