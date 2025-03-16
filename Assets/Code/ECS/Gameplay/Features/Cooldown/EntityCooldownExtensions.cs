using Code.ECS.Extensions;

namespace Code.ECS.Gameplay.Features.Cooldown
{
    public static class EntityCooldownExtensions
    {
        public static GameEntity PutOnCooldown(this GameEntity entity, float cooldown)
        {
            return entity
                    .With(x => x.ReplaceCooldownLeft(cooldown))
                    .With(x => x.ReplaceCooldown(cooldown))
                    .With(x => x.isCooldownUp = false)
                ;
        }
        
        public static GameEntity PutOnCooldown(this GameEntity entity)
        {
            if (!entity.hasCooldown)
                return entity;
            
            return entity
                    .With(x => x.ReplaceCooldown(entity.Cooldown))
                    .With(x => x.ReplaceCooldownLeft(entity.Cooldown))
                    .With(x => x.isCooldownUp = false)
                ;
        }

    }
}