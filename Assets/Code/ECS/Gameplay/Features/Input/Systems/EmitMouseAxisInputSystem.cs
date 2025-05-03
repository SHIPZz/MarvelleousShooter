using Code.Gameplay.Input;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Input.Systems
{
    public class EmitMouseAxisInputSystem : IExecuteSystem
    {
        private const float DeadZone = 0.1f;

        private readonly IGroup<InputEntity> _entities;
        private readonly IInputService _inputService;

        public EmitMouseAxisInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _entities = input.GetGroup(InputMatcher
                .AllOf(InputMatcher.Input));
        }

        public void Execute()
        {
            foreach (InputEntity entity in _entities)
            {
                float mouseX = _inputService.GetMouseX();
                float mouseY = _inputService.GetMouseY();

                if (Mathf.Abs(mouseX) <= DeadZone && Mathf.Abs(mouseY) <= DeadZone)
                    entity.isHasMouseAxis = false;
                else
                    entity.isHasMouseAxis = true;

                entity.ReplaceMouseAxis(new Vector2(mouseX, mouseY));
            }
        }
    }
}