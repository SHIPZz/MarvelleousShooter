using Code.ECS.Common.Time;
using Code.Extensions;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Cameras.Systems
{
    public class SetRecoilRotationToCameraSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroGuns;
        private readonly IGroup<GameEntity> _cameras;
        private readonly ITimeService _timeService;

        public SetRecoilRotationToCameraSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _heroGuns = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Shootable,
                    GameMatcher.HorizontalRecoil,
                    GameMatcher.Active,
                    GameMatcher.CurrentRecoil,
                    GameMatcher.ConnectedWithHero,
                    GameMatcher.VerticalRecoil
                ));

            _cameras = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.MainCamera
                ));
        }

        public void Execute()
        {
            foreach (GameEntity heroGun in _heroGuns)
            foreach (GameEntity camera in _cameras)
            {
                Quaternion recoilRotation = Quaternion.Euler(heroGun.CurrentRecoil.x, heroGun.CurrentRecoil.y, 0f);

                camera.finalRecoilRotation.Value *= recoilRotation;
            }
        }
    }
}