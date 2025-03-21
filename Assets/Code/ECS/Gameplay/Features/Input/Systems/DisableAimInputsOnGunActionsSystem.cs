using Entitas;

namespace Code.ECS.Gameplay.Features.Input.Systems
{
    public class DisableAimInputsOnGunActionsSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _input;
        private readonly IGroup<GameEntity> _disableAimInputActions;

        public DisableAimInputsOnGunActionsSystem(GameContext game, InputContext input)
        {
            _input = input.GetGroup(InputMatcher.AllOf(
                InputMatcher.Input));

            _disableAimInputActions = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ConnectedWithHero,
                    GameMatcher.Active)
                .AnyOf(
                    GameMatcher.SwitchingProcessing,
                    GameMatcher.NotAimable));
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            {
                input.isAimingAvailable = _disableAimInputActions.count <= 0;
            }
        }
    }
}