using Code.Gameplay.Cameras;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public class ApplyRecoilSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private ICameraProvider _cameraProvider;

        public ApplyRecoilSystem(GameContext game, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Shootable,
                    GameMatcher.HorizontalRecoil,
                    GameMatcher.Shooting,
                    GameMatcher.RecoilRotator,
                    GameMatcher.VerticalRecoil,
                    GameMatcher.RecoilDuration));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                var currentRotation = entity.RecoilRotator.localRotation;

                var recoilOffset = new Vector3(
                    entity.VerticalRecoil,
                    entity.HorizontalRecoil,
                    0f);

                var targetRotation = Quaternion.Euler(currentRotation.eulerAngles + recoilOffset);

                float recoilSpeed = 1f / entity.RecoilDuration;
                
                entity.RecoilRotator.localRotation = Quaternion.Slerp(
                    currentRotation,
                    targetRotation,
                    Time.deltaTime * recoilSpeed
                );

                entity.isHasRecoil = false;
            }
        }
    }
}