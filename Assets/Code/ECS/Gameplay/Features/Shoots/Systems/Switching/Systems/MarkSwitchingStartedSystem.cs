using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class MarkSwitchingStartedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _switchings;

        public MarkSwitchingStartedSystem(GameContext game)
        {
            _switchings = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.GunSwitchingAvailable,
                    GameMatcher.GunSwitchingRequested));
        }

        public void Execute()
        {
            foreach (GameEntity switching in _switchings)
            {
                switching.isSwitchingProcessed = false;
                switching.isSwitchingProcessing = true;
                switching.isSwitchingStarted = true;
            }
        }
    }
}