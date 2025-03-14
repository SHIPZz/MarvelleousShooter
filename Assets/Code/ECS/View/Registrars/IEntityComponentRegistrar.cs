namespace Code.ECS.View.Registrars
{
    public interface IEntityComponentRegistrar
    {
        void RegisterComponents();
        void UnregisterComponents();
    }
}