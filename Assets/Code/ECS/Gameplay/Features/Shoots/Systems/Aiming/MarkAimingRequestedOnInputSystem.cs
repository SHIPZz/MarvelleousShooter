using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Aiming
{
    public class MarkAimingRequestedOnInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;
        private readonly IGroup<InputEntity> _aimingPressed;

        public MarkAimingRequestedOnInputSystem(GameContext game, InputContext input)
        {
            _aimingPressed = input.GetGroup(InputMatcher.AllOf(InputMatcher.Input, InputMatcher.AimingPressed));
            
            _guns = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Gun,
                    GameMatcher.Aimable));
        }

        public void Execute()
        {
            foreach (GameEntity gun in _guns)
            {
                gun.isAimingRequested = _aimingPressed.count > 0;
            }
        }
    }
}