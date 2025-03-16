using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class OrbitCenterFollowTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _orbitCenters;
        private readonly IGroup<GameEntity> _targets;

        public OrbitCenterFollowTargetSystem(GameContext game)
        {
            _orbitCenters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.OrbitCenterPosition,
                    GameMatcher.OrbitCenterFollowTarget
                ));

            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Id
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _orbitCenters)
            foreach (GameEntity target in _targets)
            {
                if (entity.OrbitCenterFollowTarget == target.Id)
                    entity.ReplaceOrbitCenterPosition(target.WorldPosition);
            }
        }
    }
}