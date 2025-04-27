using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class ResetShootCooldownSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public ResetShootCooldownSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Shootable,GameMatcher.ShootCooldown));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (!entity.isShootAnimationProcessing)
                {
                    entity.ReplaceShootCooldownLeft(0);
                    entity.isShootCooldownUp = true;
                }
            }
        }
    }
}