using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;

namespace Code.Gameplay.Shootables.States.Transitions.Conditionals
{
    public class IsShootingCondition : ICondition
    {
        private readonly IInputService _inputService;
        private readonly IShootService _shootService;
        private readonly GameContext _game;

        public IsShootingCondition(IInputService inputService, GameContext game, IShootService shootService)
        {
            _game = game;
            _inputService = inputService;
            _shootService = shootService;
        }

        public bool IsMet()
        {
            foreach (GameEntity shootable in _game.GetGroup(GameMatcher.Shootable))
            {
                return _inputService.IsShooting() && shootable.isShootingAvailable;
            }

            return false;
        }
    }
}