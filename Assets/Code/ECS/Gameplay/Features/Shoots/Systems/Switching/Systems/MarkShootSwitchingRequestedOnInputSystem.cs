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
                .AllOf(GameMatcher.Switchable)
                .NoneOf(GameMatcher.Switching));
        }

        public void Execute()
        {
            foreach (GameEntity switchable in _entities)
            {
                switchable.isShootSwitchingRequested = _gunChangePressed.count > 0;
                
                foreach (InputEntity gunChangePressed in _gunChangePressed)
                foreach (GameEntity shoot in _shoots)
                {
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