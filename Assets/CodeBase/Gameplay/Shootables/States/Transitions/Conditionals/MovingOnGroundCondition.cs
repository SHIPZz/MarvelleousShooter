using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;

namespace CodeBase.Gameplay.Shootables.States.Conditionals
{
    public class MovingOnGroundCondition : ICondition
    {
        private readonly IInputService _inputService;
        private readonly IHeroService _heroService;

        public MovingOnGroundCondition(IInputService inputService, IHeroService heroService)
        {
            _inputService = inputService;
            _heroService = heroService;
        }

        public bool IsMet() => _inputService.HasAxisInput() && _heroService.IsOnGround;
    }
}