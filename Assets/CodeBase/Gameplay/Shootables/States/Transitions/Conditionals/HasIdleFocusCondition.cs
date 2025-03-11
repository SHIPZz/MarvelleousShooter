using CodeBase.Gameplay.Shootables.Services;

namespace CodeBase.Gameplay.Shootables.States.Conditionals
{
    public class HasIdleFocusCondition : ICondition
    {
        private readonly IShootService _shootService;

        public HasIdleFocusCondition(IShootService shootService)
        {
            _shootService = shootService;
        }

        public bool IsMet()
        {
            return _shootService.HasIdleFocus || _shootService.IsFocusing;
        }
    }
}