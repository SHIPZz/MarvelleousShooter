using Entitas;

namespace Code.ECS.Gameplay.Features.Input.Systems
{
    public class DisableShootInputsOnGunActionsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _gunSwitch;
        private readonly IGroup<InputEntity> _input;

        public DisableShootInputsOnGunActionsSystem(GameContext game,InputContext input)
        {
            _input = input.GetGroup(InputMatcher.AllOf(
                InputMatcher.Input));
            
            _gunSwitch = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.SwitchingProcessing,
                    GameMatcher.ConnectedWithHero));
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            {
                input.isShootingAvailable = _gunSwitch.count <= 0;
            }
        }
    }
}