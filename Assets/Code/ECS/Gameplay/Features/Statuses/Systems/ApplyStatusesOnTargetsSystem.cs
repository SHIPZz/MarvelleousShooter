using Code.ECS.Gameplay.Features.Statuses.Applier;
using Entitas;

namespace Code.ECS.Gameplay.Features.Statuses.Systems
{
    public class ApplyStatusesOnTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IStatusApplier _statusApplier;

        public ApplyStatusesOnTargetsSystem(GameContext game, IStatusApplier statusApplier)
        {
            _statusApplier = statusApplier;

            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.StatusSetups
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (int targetId in entity.TargetsBuffer)
            foreach (StatusSetup statusSetup in entity.StatusSetups)
            {
                _statusApplier.ApplyStatus(statusSetup, ProducerId(entity), targetId);
            }
        }

        private int ProducerId(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
    
    
}