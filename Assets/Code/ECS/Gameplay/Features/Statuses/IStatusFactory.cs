namespace Code.ECS.Gameplay.Features.Statuses
{
    public interface IStatusFactory
    {
        GameEntity CreateStatus(StatusSetup statusSetup, int targetId, int producerId);
    }
}