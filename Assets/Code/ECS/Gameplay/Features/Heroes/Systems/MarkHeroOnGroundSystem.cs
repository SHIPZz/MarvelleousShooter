using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class MarkHeroOnGroundSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public MarkHeroOnGroundSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.CharacterController));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                Debug.Log($"{hero.CharacterController.isGrounded}");
                // if(!hero.isMoving)
                //     return;
                //
                // hero.isOnGround = hero.CharacterController.isGrounded;
            }
        }
    }
}