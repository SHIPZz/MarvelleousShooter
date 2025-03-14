using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class MarkShootingRequestedOnInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<InputEntity> _inputs;

        public MarkShootingRequestedOnInputSystem(GameContext game, InputContext input)
        {
           _inputs = input.GetGroup(InputMatcher.Input);
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Shootable));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            foreach (GameEntity entity in _entities)
            {
                entity.isShootingRequested = input.isShootingPressed;
            }
        }
    }
}