namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
{
    public static class ReloadExtensions
    {
        public static GameEntity PutOnReload(this GameEntity entity)
        {
            if (!entity.hasReloadTime)
                return entity;

            entity.isReloadTimeEnded = false;
            entity.isReloading = false;
            entity.isReloadingFinished = true;

            entity.ReplaceReloadTimeLeft(entity.ReloadTime);

            return entity;
        }
    }
}