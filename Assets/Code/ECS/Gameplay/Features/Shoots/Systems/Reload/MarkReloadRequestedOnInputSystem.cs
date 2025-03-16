using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
{
    public class MarkReloadRequestedOnInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<InputEntity> _reloadPressed;
        private readonly List<GameEntity> _buffer = new(16);

        public MarkReloadRequestedOnInputSystem(GameContext game, InputContext input)
        {
            _reloadPressed = input.GetGroup(InputMatcher.ReloadingPressed);
         
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Reloadable,
                    GameMatcher.AmmoCount,
                    GameMatcher.AmmoDecreased)
                .NoneOf(GameMatcher.Reloading));
        }

        public void Execute()
        {
            foreach (InputEntity reloadPressed in _reloadPressed)
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isReloading = true;
            }
        }
    }
}