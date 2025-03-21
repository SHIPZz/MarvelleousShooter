using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class SetLastShootTimeOnShootingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _shoots;

        public SetLastShootTimeOnShootingSystem(GameContext game)
        {
           _shoots = game.GetGroup(GameMatcher.AllOf(GameMatcher.Shooting, 
                GameMatcher.Shootable,
                GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (GameEntity shoot in _shoots)
            {
                shoot.ReplaceLastShootTime(Time.time);
            }
        }
    }
    
}