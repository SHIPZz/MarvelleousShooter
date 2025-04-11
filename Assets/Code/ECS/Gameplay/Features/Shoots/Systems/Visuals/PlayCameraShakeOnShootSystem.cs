using System.Collections.Generic;
using Code.Gameplay.Cameras.Shake;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Visuals
{
    public class PlayCameraShakeOnShootSystem : ReactiveSystem<GameEntity>
    {
        private readonly ICameraShakeService _cameraShakeService;
        
        public PlayCameraShakeOnShootSystem(IContext<GameEntity> game,ICameraShakeService cameraShakeService) : base(game)
        {
            _cameraShakeService = cameraShakeService;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Shooting.Added());

        protected override bool Filter(GameEntity entity) => entity.isShootable;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                _cameraShakeService.ShakeByCameraForward();
            }
        }
    }

}