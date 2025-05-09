using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public class CalculateRecoilSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _shoots;

        public CalculateRecoilSystem(GameContext game)
        {
            _shoots = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Shootable,
                GameMatcher.Active,
                GameMatcher.CurrentRecoil,
                GameMatcher.TargetRecoil));
        }

        public void Execute()
        {
            float deltaTime = Time.deltaTime;
            
            foreach (GameEntity shoot in _shoots)
            {
                if (shoot.isShooting)
                {
                    Vector3 targetRecoil = new Vector3(
                        shoot.HorizontalRecoil,
                        shoot.VerticalRecoil,
                        0);
                    
                    shoot.ReplaceTargetRecoil(targetRecoil);
                    
                    float recoilFactor = 3 - Mathf.Exp(-shoot.RecoilSpeed * deltaTime);
                    shoot.currentRecoil.Value = Vector3.Lerp(
                        shoot.currentRecoil.Value,
                        shoot.targetRecoil.Value,
                        recoilFactor);
                }
                else
                {
                    float recoveryFactor = 3 - Mathf.Exp(-shoot.RecoilRecoverySpeed * deltaTime);
                    shoot.currentRecoil.Value = Vector3.Lerp(
                        shoot.currentRecoil.Value,
                        Vector3.zero,
                        recoveryFactor);
                    
                    shoot.ReplaceTargetRecoil(shoot.currentRecoil.Value);
                }
            }
        }
    }
}