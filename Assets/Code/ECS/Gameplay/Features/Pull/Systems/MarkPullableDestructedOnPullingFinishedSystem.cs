using Entitas;

namespace Code.ECS.Gameplay.Features.Pull.Systems
{
    public class MarkPullableDestructedOnPullingFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private GameContext _game;

        public MarkPullableDestructedOnPullingFinishedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Pullable,
                    GameMatcher.FollowingUp,
                    GameMatcher.Pulling
                    ).NoneOf(GameMatcher.CurrentHp));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isDestructed = true;
            }
        }
    }
}