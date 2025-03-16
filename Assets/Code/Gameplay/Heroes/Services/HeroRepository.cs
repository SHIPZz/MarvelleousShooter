using System.Collections.Generic;

namespace Code.Gameplay.Heroes.Services
{
    public class HeroRepository : IHeroRepository
    {
        private readonly Dictionary<HeroTypeId, GameEntity> _heroes = new();
        
        public GameEntity CurrentGun { get; private set; }

        public GameEntity Load() => _heroes[HeroTypeId.Main];

        public void SetCurrentGun(GameEntity entity)
        {
            CurrentGun = entity;
        }

        public void Add(GameEntity hero) => _heroes[HeroTypeId.Main] = hero;
    }
}