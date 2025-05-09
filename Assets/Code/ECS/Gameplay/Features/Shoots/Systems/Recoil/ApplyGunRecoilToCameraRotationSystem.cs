using Code.ECS.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public class ApplyGunRecoilToCameraRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroGuns;
        private readonly IGroup<GameEntity> _cameras;
        private readonly ITimeService _timeService;
        
        public ApplyGunRecoilToCameraRotationSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _heroGuns = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Gun,
                GameMatcher.HorizontalRecoil,
                GameMatcher.Active,
                GameMatcher.CurrentRecoil,
                GameMatcher.ConnectedWithHero,
                GameMatcher.VerticalRecoil));

            _cameras = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.MainCamera,
                GameMatcher.RecoilRotation,
                GameMatcher.FinalRecoilRotation));
        }

        public void Execute()
        {
            float deltaTime = _timeService.DeltaTime;
            
            foreach (GameEntity heroGun in _heroGuns)
            foreach (GameEntity camera in _cameras)
            {
                Quaternion targetRecoilRotation = Quaternion.Euler(
                    heroGun.CurrentRecoil.y, 
                    heroGun.CurrentRecoil.x, 
                    0f);

                camera.ReplaceRecoilRotation(Quaternion.Slerp(
                    camera.RecoilRotation,
                    targetRecoilRotation,
                    heroGun.RecoilSpeed * deltaTime
                ));

                float returnFactor = heroGun.isShootingContinuously ? 0.1f : 1f;
                
                Quaternion returnRotation = Quaternion.Slerp(
                    camera.RecoilRotation,
                    Quaternion.identity,
                    heroGun.RecoilRecoverySpeed * returnFactor * deltaTime
                );

                camera.ReplaceRecoilRotation(returnRotation);

                camera.ReplaceFinalRecoilRotation(camera.RecoilRotation);
            }
        }
    }
}