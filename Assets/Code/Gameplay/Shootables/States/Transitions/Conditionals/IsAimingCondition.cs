using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;

namespace Code.Gameplay.Shootables.States.Transitions.Conditionals
{
    public class IsAimingCondition : ICondition
    {
        private readonly IInputService _inputService;
        private readonly IShootService _shootService;
        private GameContext _game;

        public IsAimingCondition(IInputService inputService, IShootService shootService, GameContext game)
        {
            _inputService = inputService;
            _shootService = shootService;
            _game = game;
        }

        public bool IsMet()
        {
            foreach (GameEntity shootable in _game.GetGroup(GameMatcher.Shootable))
            {
                return shootable.isAimable && shootable.isAiming;
            }
            
            return false;
        }
    }
}