using Code.Gameplay.Heroes.Services;

namespace Code.Gameplay.Shootables.States.Transitions.Conditionals
{
    public class OnGroundCondition : ICondition
    {
        private readonly IHeroService _heroService;

        public OnGroundCondition(IHeroService heroService)
        {
            _heroService = heroService;
        }

        public bool IsMet() => true;
    }
}