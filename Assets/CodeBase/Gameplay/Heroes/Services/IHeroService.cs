namespace CodeBase.Gameplay.Heroes.Services
{
    public interface IHeroService
    {
        Hero CreateHero();
        
        public Hero Hero { get; }
        
        bool IsOnGround { get; }
        HeroMovement HeroMovement { get; }
    }
}