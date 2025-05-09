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
                GameMatcher.Shootable,
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
                Quaternion newRecoilRotation = Quaternion.Euler(
                    heroGun.CurrentRecoil.y,
                    heroGun.CurrentRecoil.x, 
                    0f);

                camera.ReplaceRecoilRotation(newRecoilRotation);

                if (heroGun.CurrentRecoil != Vector3.zero)
                {
                    camera.finalRecoilRotation.Value *= newRecoilRotation;
                }
                else 
                {
                    float recoveryFactor = 1 - Mathf.Exp(-heroGun.RecoilRecoverySpeed * deltaTime);
                    camera.finalRecoilRotation.Value = Quaternion.Slerp(
                        camera.finalRecoilRotation.Value,
                        Quaternion.identity,
                        recoveryFactor);
                    
                    if (Quaternion.Angle(camera.FinalRecoilRotation, Quaternion.identity) < 0.1f)
                    {
                        camera.ReplaceFinalRecoilRotation(Quaternion.identity);
                    }
                }
            }
        }
    }
}