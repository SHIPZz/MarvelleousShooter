using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class SetMovementDirectionByCameraDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<InputEntity> _input;
        private readonly IGroup<GameEntity> _cameras;

        public SetMovementDirectionByCameraDirectionSystem(GameContext game, InputContext input)
        {
            _input = input.GetGroup(InputMatcher.Input);

            _cameras = game
                .GetGroup(GameMatcher.AllOf(
                    GameMatcher.MainCamera));
            
            _entities = game
                .GetGroup(GameMatcher.AllOf(
                    GameMatcher.Speed,
                    GameMatcher.Active,
                    GameMatcher.OnGround,
                    GameMatcher.Hero));
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            foreach (GameEntity camera in _cameras)
            foreach (GameEntity entity in _entities)
            {
                Vector3 inputAxis = input.Axis;
                
                Vector3 forward = camera.Transform.forward;
                Vector3 right = camera.Transform.right;

                forward.y = 0;
                right.y = 0;

                forward.Normalize();
                right.Normalize();

                Vector3 direction = right * inputAxis.x + forward * inputAxis.z;
                entity.ReplaceDirection(direction.normalized);

            }
        }
    }
}