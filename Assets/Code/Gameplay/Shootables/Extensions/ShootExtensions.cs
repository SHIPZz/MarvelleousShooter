namespace Code.Gameplay.Shootables.Extensions
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