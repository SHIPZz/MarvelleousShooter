using CodeBase.Gameplay.Enemies;
using CodeBase.Gameplay.Heroes;
using CodeBase.Gameplay.Heroes.Services;

namespace CodeBase.Gameplay.TargetSelectors
{
    public class TargetSelector : ITargetSelector
    {
        private readonly IHeroService _heroService;

        public TargetSelector(IHeroService heroService)
        {
            _heroService = heroService;
        }
        
        public Hero SelectTarget(EnemyTypeId enemyTypeId)
        {
            return _heroService.Hero;
        }
    }
}