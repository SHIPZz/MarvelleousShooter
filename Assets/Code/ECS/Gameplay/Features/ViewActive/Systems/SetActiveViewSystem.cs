using Entitas;

namespace Code.ECS.Gameplay.Features.ViewActive.Systems
{
    public class SetActiveViewSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SetActiveViewSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.View).NoneOf(GameMatcher.Destructed));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.View != null && entity.View.gameObject != null)
                    entity.View.gameObject.SetActive(entity.isViewActive);
            }
        }
    }
}