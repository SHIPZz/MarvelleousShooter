namespace Code.Gameplay.Heroes.Services
{
    public interface IHeroRepository
    {
        GameEntity Load();
        void Add(GameEntity hero);
        GameEntity CurrentGun { get; }
        void SetCurrentGun(GameEntity entity);
    }
}