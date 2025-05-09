using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class MarkSwitchingRequestedOnInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _switchings;
        private readonly IGroup<InputEntity> _gunChangePressed;

        public MarkSwitchingRequestedOnInputSystem(GameContext game, InputContext input)
        {
            _gunChangePressed = input.GetGroup(InputMatcher.AllOf(
                InputMatcher.GunChangePressed,
                InputMatcher.SelectedShoot));

            _switchings = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Switchable));
        }

        public void Execute()
        {
            foreach (GameEntity switching in _switchings)
            {
                switching.isShootSwitchingRequested = _gunChangePressed.count > 0;

                foreach (InputEntity input in _gunChangePressed)
                    switching.ReplaceTargetInputGun(input.SelectedShoot);
            }
        }
    }
}