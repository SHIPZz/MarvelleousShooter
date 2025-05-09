using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.DoubleShoots.Systems
{
    public class MarkDoubleShootingRequestedOnInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<InputEntity> _inputs;

        public MarkDoubleShootingRequestedOnInputSystem(GameContext game,InputContext input)
        {
           _inputs = input
               .GetGroup(
                   InputMatcher.AllOf(
                           InputMatcher.Input,
               InputMatcher.DoubleShootingAvailable,
               InputMatcher.DoubleShootingRequested));
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.DoubleShootingAvailable,
                    GameMatcher.Shootable,
                    GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (_inputs.count > 0)
                {
                    entity.isDoubleShootRequested = true;
                    entity.isDoubleShooting = true;
                }
            }
        }
    }
}