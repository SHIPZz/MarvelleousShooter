using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Cooldowns
{
    public class MarkShootCooldownProcessingOnShootSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkShootCooldownProcessingOnShootSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Shooting,
                    GameMatcher.Shootable)
                .NoneOf(GameMatcher.ShootCooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isShootCooldownProcessing = true;
            }
        }
    }
}