using Entitas;

namespace Code.ECS.Gameplay.Features.Pull.Systems
{
    public class MarkPullableDeadOnPullingFinishedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private GameContext _game;

        public MarkPullableDeadOnPullingFinishedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Pullable,
                    GameMatcher.FollowingUp,
                    GameMatcher.CurrentHp,
                    GameMatcher.Alive,
                    GameMatcher.Pulling
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceCurrentHp(0);
            }
        }
    }
}