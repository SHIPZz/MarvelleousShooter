namespace Code.ECS.Gameplay.Features.Shoots.Extensions
{
    public static class ShootExtensions
    {
        public static GameEntity PutOnAmmo(this GameEntity entity)
        {
            if (!entity.hasAmmoCount)
                return entity;

            entity.ReplaceAmmoCountLeft(entity.AmmoCount);

            return entity;
        }
    }
}