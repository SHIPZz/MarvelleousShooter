using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public class ResetCameraRecoilSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(2);

        public ResetCameraRecoilSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HasRecoil,
                    GameMatcher.RecoilRotator,
                    GameMatcher.CurrentCameraRotation,
                    GameMatcher.TargetCameraRotation,
                    GameMatcher.RecoilRecoverySpeed
                )
                .NoneOf(GameMatcher.RecoilRecovering));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                var currentRotation = entity.currentCameraRotation.Value;
                var targetRotation = entity.targetCameraRotation.Value;
                var recoverySpeed = entity.recoilRecoverySpeed.Value;

                // Плавно возвращаем целевую ротацию к нулю
                targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, recoverySpeed * Time.deltaTime);

                // Плавно интерполируем текущую ротацию к целевой
                currentRotation = Vector3.Lerp(currentRotation, targetRotation, recoverySpeed * Time.deltaTime);

                // Обновляем компоненты
                entity.ReplaceCurrentCameraRotation(currentRotation);
                entity.ReplaceTargetCameraRotation(targetRotation);

                // Применяем ротацию к камере
                entity.recoilRotator.Value.localRotation = Quaternion.Euler(currentRotation);

                // Если ротация достаточно близка к нулю, добавляем флаг восстановления
                if (Vector3.Distance(currentRotation, Vector3.zero) < 0.01f)
                {
                    entity.isRecoilRecovering = true;
                }
            }
        }
    }
} 