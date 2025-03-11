using CodeBase.Gameplay.Common.Configs;
using CodeBase.Gameplay.Heroes.Configs;
using CodeBase.Gameplay.Shootables.Configs;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers.Config
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
