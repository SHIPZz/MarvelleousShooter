using Code.Gameplay.Common.Services.Raycast;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class CleanupShootRaycastHitsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly IShootRaycastService _raycastService;

        public CleanupShootRaycastHitsSystem(IShootRaycastService raycastService, GameContext game)
        {
            _raycastService = raycastService;
            
            _group = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hits, 
                GameMatcher.Shootable));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group)
            {
                 _raycastService.ClearRaycastHits();
                 entity.ReplaceHits(null);
            }
        }
    }
}