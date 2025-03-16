using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class StopShootingOnNoInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<InputEntity> _inputs;

        public StopShootingOnNoInputSystem(GameContext game, InputContext input)
        {
            _inputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.Input,InputMatcher.ShootingPressed));

            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Shootable));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (_inputs.count <= 0)
                    entity.isShooting = false;
            }
        }
    }
}