using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class CleanupSwitchingSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(2);

        public CleanupSwitchingSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Switching,
                GameMatcher.TargetGunShown,
                GameMatcher.PreviousGunHidden));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.isSwitching = false;
                entity.isTargetGunShown = false;
                entity.isPreviousGunHidden = false;
                entity.RemoveTargetSwitchGunId();
                entity.RemovePreviousSwitchedGunId();
            }
        }
    }
}