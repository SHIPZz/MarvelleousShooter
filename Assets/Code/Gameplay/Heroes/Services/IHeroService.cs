namespace Code.Gameplay.Heroes.Services
{
    public interface IHeroService
    {
        GameEntity CreateHero();
        
        GameEntity LoadHero();
    }
}