using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public class CalculateCurrentRecoilSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;

        public CalculateCurrentRecoilSystem(GameContext game)
        {
            _guns = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Gun,
                GameMatcher.Active,
                GameMatcher.CurrentRecoil,
                GameMatcher.TargetRecoil));
        }

        public void Execute()
        {
            float deltaTime = Time.deltaTime;
            
            foreach (GameEntity gun in _guns)
            {
                if (gun.isShootingContinuously)
                {
                    Vector3 targetRecoil = new Vector3(
                        gun.HorizontalRecoil,
                        gun.VerticalRecoil,
                        0);
                    
                    gun.ReplaceCurrentRecoil(targetRecoil);
                }
                else
                {
                    gun.currentRecoil.Value = Vector3.Lerp(
                        gun.currentRecoil.Value,
                        Vector3.zero,
                        gun.RecoilRecoverySpeed * deltaTime);
                }
            }
        }
    }
}