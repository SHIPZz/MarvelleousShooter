using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Visuals
{
    public class AllowIdleFocusPlayingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public AllowIdleFocusPlayingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HasIdleFocus,
                    GameMatcher.AnimancerAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isIdleFocusAvailable = true;
            }
        }
    }
}