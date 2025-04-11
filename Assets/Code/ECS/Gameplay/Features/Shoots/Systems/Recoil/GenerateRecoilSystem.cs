using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public class GenerateRecoilSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _shoots;

        public GenerateRecoilSystem(GameContext game)
        {
            _shoots = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Shootable,GameMatcher.Shooting));
        }

        public void Execute()
        {
            foreach (GameEntity shoot in _shoots)
            {
                Vector2 horizontalRecoil = shoot.Patterns[shoot.RecoilPatternIndex];
                shoot.ReplaceHorizontalRecoil(horizontalRecoil.x);
                shoot.ReplaceVerticalRecoil(horizontalRecoil.y);
                
                shoot.ReplaceRecoilPatternIndex(shoot.RecoilPatternIndex + 1);
                
                if(shoot.RecoilPatternIndex > shoot.Patterns.Length - 1) 
                    shoot.ReplaceRecoilPatternIndex(0);
            }
        }
    }
}