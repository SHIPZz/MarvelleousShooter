using Entitas;

namespace Code.ECS.Gameplay.Features.Input
{
    public class DisableInputsOnSwitchingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _gunSwitch;
        private readonly IGroup<InputEntity> _input;

        public DisableInputsOnSwitchingSystem(GameContext game,InputContext input)
        {
            _input = input.GetGroup(InputMatcher.AllOf(
                InputMatcher.Input));
            
            _gunSwitch = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Switching));
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            {
                input.isAimingAvailable = _gunSwitch.count <= 0;
                input.isShootingAvailable = _gunSwitch.count <= 0;
                input.isReloadAvailable = _gunSwitch.count <= 0;
            }
        }
    }
}