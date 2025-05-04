using Code.Data.Services;
using Code.ECS.Common.Collisions;
using Code.ECS.Common.Physics;
using Code.ECS.Common.Services;
using Code.ECS.Common.Time;
using Code.ECS.Gameplay.Features.Cameras.Factories;
using Code.ECS.Infrastructure.StateMachine;
using Code.ECS.Systems;
using Code.ECS.View.Factory;
using Code.Gameplay.Cameras;
using Code.Gameplay.Cameras.Shake;
using Code.Gameplay.Common;
using Code.Gameplay.Common.Services.Raycast;
using Code.Gameplay.Common.Timer;
using Code.Gameplay.Effects;
using Code.Gameplay.Enemies;
using Code.Gameplay.Enemies.Factory;
using Code.Gameplay.Enemies.Services;
using Code.Gameplay.Heroes.Factory;
using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using Code.Gameplay.LevelDatas;
using Code.Gameplay.Shootables.Factory;
using Code.Gameplay.Sounds;
using Code.InfraStructure.AssetManagement_1;
using Code.InfraStructure.AssetManagement;
using Code.InfraStructure.Loading;
using Code.InfraStructure.States.Factory;
using Code.InfraStructure.States.States;
using Code.UI;
using Zenject;

namespace Code.Installers.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        // [SerializeField] private LoadingCurtain _loadingCurtain;

        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindSceneLoader();
            BindStateFactory();
            BindWorldDataService();
            BindStaticDataServices();
            BindInputService();
            BindSoundServices();
            BindCameraServices();
            BindStates();
            BindAssetManagementServices();
            BindEffectServices();
            BindLevelDataProvider();
            BindShootServices();
            BindHeroServices();
            BindEnemyServices();
            BindGameplayServices();
            BindWindowService();
            BindEcsServices();
            BindContexts();

            Container.BindInterfacesTo<UpdateService>().AsSingle();
            
            Container.BindInterfacesTo<BootstrapInstaller>()
                .FromInstance(this);
        }

        private void BindContexts()
        {
            Container.BindInterfacesAndSelfTo<GameContext>().FromInstance(Contexts.sharedInstance.game);
            Container.BindInterfacesAndSelfTo<InputContext>().FromInstance(Contexts.sharedInstance.input);
            Container.BindInterfacesAndSelfTo<MetaContext>().FromInstance(Contexts.sharedInstance.meta);
            
            
        }

        private void BindEcsServices()
        {
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
            Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
        }

        public void Initialize()
        {
            var gameStateMachine = Container.Resolve<IGameStateMachine>();
            gameStateMachine.Enter<BootstrapState>();
        }

        private void BindWindowService()
        {
            Container.BindInterfacesAndSelfTo<WindowService>().AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.BindInterfacesTo<TimerService>().AsTransient();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<IRaycastService>().To<RaycastHitService>().AsSingle();
        }

        private void BindEnemyServices()
        {
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<IEnemyService>().To<EnemyService>().AsSingle();
            Container.Bind<IEnemyStaticDataService>().To<EnemyStaticDataService>().AsSingle();
        }

        private void BindShootServices()
        {
            Container.Bind<IShootFactory>().To<ShootFactory>().AsSingle();
        }

        private void BindHeroServices()
        {
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle(); 
            Container.BindInterfacesTo<HeroRepository>().AsSingle();
        }

        private void BindLevelDataProvider()
        {
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<IUIProvider>().To<UIProvider>().AsSingle();
        }

        private void BindEffectServices()
        {
            Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
        }

        private void BindAssetManagementServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            // Container.Bind<IAssetDownloadService>().To<LabeledAssetDownloadService>().AsSingle();
            // Container.Bind<IAssetDownloadReporter>().To<AssetDownloadReporter>().AsSingle();
        }

        private void BindStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelLoadState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameState>().AsSingle();
        }

        private void BindCameraServices()
        {
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.Bind<ICameraShakeService>().To<CameraShakeService>().AsSingle();
            Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
        }

        private void BindSoundServices()
        {
            Container.Bind<ISoundService>().To<SoundService>().AsSingle();
            Container.Bind<ISoundFactory>().To<SoundFactory>().AsSingle();
        }

        private void BindInputService()
        {
            Container.BindInterfacesTo<StandaloneInputService>().AsSingle();
        }

        private void BindStaticDataServices()
        {
            Container.BindInterfacesTo<UIStaticDataService>().AsSingle();
            Container.Bind<IEffectStaticDataService>().To<EffectStaticDataService>().AsSingle();
            Container.Bind<ISoundStaticDataService>().To<SoundStaticDataService>().AsSingle();
        }

        private void BindWorldDataService()
        {
            Container.Bind<IWorldDataService>().To<WorldDataService>().AsSingle();
        }

        private void BindInterfacesAndSelf<T>() =>
            Container.BindInterfacesAndSelfTo<T>().AsSingle();

        private void BindAsSingle<T>()
        {
            Container.Bind<T>().AsSingle();
        }

        private void BindStateFactory() =>
            Container
                .Bind<IStateFactory>()
                .To<StateFactory>()
                .AsSingle();

        private void BindGameStateMachine() =>
            Container.BindInterfacesTo<GameStateMachine>()
                .AsSingle();
    }
}