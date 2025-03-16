using Code.Gameplay.Animations;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Visuals
{
    public class AnimateWalkingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public AnimateWalkingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AnimancerAnimator,
                    GameMatcher.Walking,
                    GameMatcher.Moving,
                    GameMatcher.MovementAnimAvailable
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.AnimancerAnimator.StartAnimation(AnimationTypeId.Walk);
            }
        }
    }
    
}