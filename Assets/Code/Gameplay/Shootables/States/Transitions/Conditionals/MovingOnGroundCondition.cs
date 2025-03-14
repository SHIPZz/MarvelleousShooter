using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;

namespace Code.Gameplay.Shootables.States.Transitions.Conditionals
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

        public bool IsMet() => _inputService.HasAxisInput() && true;
    }
}