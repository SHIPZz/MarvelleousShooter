using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class MarkHeroOnGroundSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public MarkHeroOnGroundSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero,GameMatcher.CharacterMovement));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                hero.isOnGround = hero.CharacterMovement.isOnGround;
            }
        }
    }
}