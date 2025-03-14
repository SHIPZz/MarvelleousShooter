using Code.Gameplay.Common.Configs;
using Code.Gameplay.Heroes.Configs;
using Code.Gameplay.Shootables.Configs;
using UnityEngine;
using Zenject;

namespace Code.Installers.Config
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private DamageConfig _damageConfig;
        [SerializeField] private ShootConfigs shootConfigs;
        [SerializeField] private HeroConfig _heroConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_damageConfig);
            Container.BindInstance(_heroConfig);
            Container.BindInstance(shootConfigs);
        }
    }
}
