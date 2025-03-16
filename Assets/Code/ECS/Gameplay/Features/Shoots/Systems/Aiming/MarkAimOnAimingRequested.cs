using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Aiming
{
    public class MarkAimOnAimingRequested : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkAimOnAimingRequested(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Aimable));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isAiming = entity.isAimingRequested && entity.isAimingAvailable;
            }
        }
    }
}