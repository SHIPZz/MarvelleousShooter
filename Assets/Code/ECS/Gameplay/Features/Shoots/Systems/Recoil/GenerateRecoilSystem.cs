using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public class GenerateRecoilSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;

        public GenerateRecoilSystem(GameContext game)
        {
            _guns = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Gun,
                    GameMatcher.Shooting,
                    GameMatcher.Patterns,
                    GameMatcher.RecoilPatternIndex));
        }

        public void Execute()
        {
            foreach (GameEntity shoot in _guns)
            {
                Vector2 horizontalRecoil = shoot.Patterns[shoot.RecoilPatternIndex];
                shoot.ReplaceHorizontalRecoil(horizontalRecoil.x);
                shoot.ReplaceVerticalRecoil(-horizontalRecoil.y);
                
                shoot.ReplaceRecoilPatternIndex(shoot.RecoilPatternIndex + 1);
                
                if(shoot.RecoilPatternIndex > shoot.Patterns.Length - 1) 
                    shoot.ReplaceRecoilPatternIndex(0);
            }
        }
    }
}