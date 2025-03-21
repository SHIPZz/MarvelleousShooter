using Entitas;

namespace Code.ECS.Gameplay.Features.Input
{
    public class DisableReloadInputOnGunActionsSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _input;
        private readonly IGroup<GameEntity> _disableAimInputActions;

        public DisableReloadInputOnGunActionsSystem(GameContext game,InputContext input)
        {
            _input = input.GetGroup(InputMatcher.AllOf(
                InputMatcher.Input));
            
            _disableAimInputActions = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ConnectedWithHero, 
                    GameMatcher.Active)
                .AnyOf(GameMatcher.SwitchingProcessing,GameMatcher.Reloading));
        }

        public void Execute()
        {
            foreach (InputEntity input in _input)
            {
                input.isReloadAvailable = _disableAimInputActions.count <= 0;
            }
        }
    }
}