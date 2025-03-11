using CodeBase.Gameplay.Heroes.Services;

namespace CodeBase.Gameplay.Shootables.States.Conditionals
{
    public class OnGroundCondition : ICondition
    {
        private readonly IHeroService _heroService;

        public OnGroundCondition(IHeroService heroService)
        {
            _heroService = heroService;
        }

        public bool IsMet() => _heroService.IsOnGround;
    }
}