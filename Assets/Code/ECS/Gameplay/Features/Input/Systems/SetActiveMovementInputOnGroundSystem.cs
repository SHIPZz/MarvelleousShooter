using Entitas;

namespace Code.ECS.Gameplay.Features.Input.Systems
{
    public class SetActiveMovementInputOnGroundSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _input;
        private readonly IGroup<GameEntity> _heroes;

        public SetActiveMovementInputOnGroundSystem(GameContext game,InputContext input)
        {
            _input = input.GetGroup(InputMatcher.AllOf(
                InputMatcher.Input));

            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.Movable));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (InputEntity input in _input)
            {
                input.isMovementAvailable = hero.isOnGround;
                input.isJumpingAvailable = hero.isOnGround;
            }
        }
    }
}