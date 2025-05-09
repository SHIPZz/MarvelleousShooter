using Entitas;

namespace Code.ECS.Gameplay.Features.TargetCollection.Systems
{
    public class SetCastPositionFromCameraSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _cameras;

        public SetCastPositionFromCameraSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.CanRaycast,GameMatcher.CastFromCamera));
            
            _cameras = game.GetGroup(GameMatcher.AllOf(GameMatcher.MainCamera,GameMatcher.Transform));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (GameEntity camera in _cameras)
            {
                entity.ReplaceCastDirection(camera.Transform.forward);
                entity.ReplaceCastFromTargetTransform(camera.Transform);
            }
        }
    }
}