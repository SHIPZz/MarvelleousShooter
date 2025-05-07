using Code.Extensions;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Cameras.Systems
{
    public class ApplyCameraFinalRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cameras;

        public ApplyCameraFinalRotationSystem(GameContext game)
        {
            _cameras = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MainCamera,
                    GameMatcher.BaseCameraRotation,
                    GameMatcher.RecoilRotation,
                    GameMatcher.ConnectedWithHero
                ));
        }

        public void Execute()
        {
            foreach (GameEntity camera in _cameras)
            {
                camera.Transform.localRotation = camera.BaseCameraRotation * camera.FinalRecoilRotation;
                Vector3 transformEulerAngles = camera.Transform.eulerAngles;
                transformEulerAngles.z = 0;
                
                camera.Transform.localRotation = Quaternion.Euler(transformEulerAngles);
            }
        }
    }
}