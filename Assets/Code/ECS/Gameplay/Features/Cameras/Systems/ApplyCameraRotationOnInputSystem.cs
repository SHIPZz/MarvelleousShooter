using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Cameras.Systems
{
    public class ApplyCameraRotationOnInputSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly IGroup<GameEntity> _cameras;
        private readonly IGroup<InputEntity> _inputs;
        
        public ApplyCameraRotationOnInputSystem(GameContext game, InputContext input)
                
        {
            _inputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.Input,InputMatcher.HasMouseAxis));
            
            _cameras = game.GetGroup(GameMatcher.AllOf(GameMatcher.MainCamera,
                GameMatcher.CameraRotationSpeed,
                GameMatcher.MinCameraRotation,
                GameMatcher.MaxCameraRotation,
                GameMatcher.CameraRotationSharpness));
        }

        public void Initialize()
        {
                Cursor.lockState = CursorLockMode.Locked;
        }

        public void Execute()
        {
            foreach (var inputEntity in _inputs)
            foreach (GameEntity camera in _cameras)
            {
                Vector2 inputMouse = inputEntity.MouseAxis;

                float sensitivity = camera.CameraRotationSpeed;

                float pitchDelta = -inputMouse.y * sensitivity;
                float yawDelta = inputMouse.x * sensitivity;

                float newPitch = Mathf.Clamp(camera.VerticalRotation + pitchDelta, camera.MinCameraRotation, camera.MaxCameraRotation);
                float newYaw = camera.HorizontalRotation + yawDelta;

                camera.ReplaceVerticalRotation(newPitch);
                camera.ReplaceHorizontalRotation(newYaw);

                Quaternion targetRotation = Quaternion.Euler(newPitch, newYaw, 0f);
                camera.Transform.localRotation = Quaternion.Slerp(camera.Transform.localRotation, targetRotation, 1f - Mathf.Exp(-camera.CameraRotationSharpness * Time.deltaTime)); 
            }
        }
    }
}