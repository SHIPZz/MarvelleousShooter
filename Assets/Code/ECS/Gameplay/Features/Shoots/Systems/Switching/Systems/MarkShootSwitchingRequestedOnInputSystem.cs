using Code.Gameplay.Heroes.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class MarkShootSwitchingRequestedOnInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<InputEntity> _gunChangePressed;
        private readonly IGroup<GameEntity> _shoots;

        public MarkShootSwitchingRequestedOnInputSystem(GameContext game, InputContext input)
        {
            _gunChangePressed = input.GetGroup(InputMatcher.GunChangePressed);

            _shoots = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Shootable,
                GameMatcher.ShowInputKey, 
                GameMatcher.Id));

            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Switchable));
        }

        public void Execute()
        {
            foreach (GameEntity switchable in _entities)
            {
                switchable.isShootSwitchingRequested = false;

                foreach (InputEntity gunChangePressed in _gunChangePressed)
                foreach (GameEntity shoot in _shoots)
                {
                    switchable.isShootSwitchingRequested = true;

                    if (!TryGetTargetShootIdByInput(shoot, gunChangePressed, out var targetId)) 
                        continue;

                    switchable.ReplaceTargetSwitchGunId(targetId);
                }
            }
        }

        private static bool TryGetTargetShootIdByInput(GameEntity shoot, InputEntity gunChangePressed, out int targetId)
        {
            targetId = 0;

            if (shoot.ShowInputKey != gunChangePressed.SelectedShoot)
                return false;

            targetId = shoot.Id;
            return true;
        }
    }
}