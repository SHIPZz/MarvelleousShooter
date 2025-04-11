using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public class ApplyRecoilSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(2);

        public ApplyRecoilSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HasRecoil,
                    GameMatcher.RecoilRotator,
                    GameMatcher.CurrentCameraRotation,
                    GameMatcher.TargetCameraRotation,
                    GameMatcher.VerticalRecoil,
                    GameMatcher.HorizontalRecoil
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                var currentRotation = entity.currentCameraRotation.Value;
                var targetRotation = entity.targetCameraRotation.Value;
                var smoothing = entity.cameraRecoilSmoothing.Value;
                var verticalRecoil = entity.verticalRecoil.Value;
                var horizontalRecoil = entity.horizontalRecoil.Value;

                // Применяем отдачу к целевой ротации
                targetRotation.x += verticalRecoil;
                targetRotation.y += horizontalRecoil;

                // Плавно интерполируем текущую ротацию к целевой
                currentRotation = Vector3.Lerp(currentRotation, targetRotation, smoothing * Time.deltaTime);

                // Обновляем компоненты
                entity.ReplaceCurrentCameraRotation(currentRotation);
                entity.ReplaceTargetCameraRotation(targetRotation);

                // Применяем ротацию к камере
                entity.recoilRotator.Value.localRotation = Quaternion.Euler(currentRotation);
            }
        }
    }
} 