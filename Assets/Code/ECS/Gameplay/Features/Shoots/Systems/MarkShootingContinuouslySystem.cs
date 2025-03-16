using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class MarkShootingContinuouslySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkShootingContinuouslySystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Shootable, 
                    GameMatcher.HeroGun 
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isShootingContinuously = entity.isShootingRequested 
                                                && entity.isShootingAvailable;
            }
        }
    }
}