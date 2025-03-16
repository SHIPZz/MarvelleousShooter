using Entitas;

namespace Code.ECS.Gameplay.Features.Follow.Systems
{
    public class UpdateLastFollowTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public UpdateLastFollowTargetsSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LastFollowTargets,
                    GameMatcher.FollowTargetId
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if(entity.LastFollowTargets.Contains(entity.FollowTargetId))
                    continue;
                
                entity.LastFollowTargets.Add(entity.FollowTargetId);
            }
        }
    }
}