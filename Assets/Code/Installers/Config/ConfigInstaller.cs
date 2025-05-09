using Code.ECS.Gameplay.Features.Cameras.Configs;
using Code.ECS.Gameplay.Features.Heroes.Configs;
using Code.ECS.Gameplay.Features.Shoots.Configs;
using UnityEngine;
using Zenject;

namespace Code.Installers.Config
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private ShootConfigs shootConfigs;
        [SerializeField] private HeroConfig _heroConfig;
        [SerializeField] private CameraConfig _cameraConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_heroConfig);
            Container.BindInstance(shootConfigs);
            Container.BindInstance(_cameraConfig);
        }
    }
}
