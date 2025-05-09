using Code.Gameplay.Common.Services.Raycast;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Cleanups
{
    public class CleanupShootRaycastHitsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _guns;
        private readonly IRaycastService _raycastService;

        public CleanupShootRaycastHitsSystem(IRaycastService raycastService, GameContext game)
        {
            _raycastService = raycastService;

            _guns = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hits,
                GameMatcher.Shootable));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _guns)
            {
                _raycastService.ClearRaycastHits();
                
                if (entity.Hits.Count > 0)
                    entity.Hits.Clear();
                
                entity.isHitDetected = false;
            }
        }
    }
}