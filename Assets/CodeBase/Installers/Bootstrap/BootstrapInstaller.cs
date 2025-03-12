using CodeBase.Data.Services;
using CodeBase.Gameplay.AbilitySystem;
using CodeBase.Gameplay.AbilitySystem.StatSystem.StatModifiers;
using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Cameras.Shake;
using CodeBase.Gameplay.Common;
using CodeBase.Gameplay.Common.Damage;
using CodeBase.Gameplay.Common.Services.Raycast;
using CodeBase.Gameplay.Common.Time;
using CodeBase.Gameplay.Common.Timer;
using CodeBase.Gameplay.Effects;
using CodeBase.Gameplay.Enemies;
using CodeBase.Gameplay.Enemies.Factory;
using CodeBase.Gameplay.Enemies.Services;
using CodeBase.Gameplay.Heroes;
using CodeBase.Gameplay.Heroes.Factory;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.LevelDatas;
using CodeBase.Gameplay.Quest.Services;
using CodeBase.Gameplay.Shootables.Factory;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.States;
using CodeBase.Gameplay.Shootables.States.Conditionals;
using CodeBase.Gameplay.Shootables.Switcher;
using CodeBase.Gameplay.Sounds;
using CodeBase.Gameplay.TargetSelectors;
using CodeBase.InfraStructure.AssetManagement_1;
using CodeBase.InfraStructure.Loading;
using CodeBase.InfraStructure.States.Factory;
using CodeBase.InfraStructure.States.StateMachine;
using CodeBase.InfraStructure.States.States;
using CodeBase.UI;
using Zenject;

namespace CodeBase.Installers.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        // [SerializeField] private LoadingCurtain _loadingCurtain;

        public override void InstallBindings()
        {
            // BindLoadingCurtain();
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
            BindQuestServices();
            BindEffectServices();
            BindLevelDataProvider();
            BindShootServices();
            BindHeroServices();
            BindEnemyServices();
            BindAbilityServices();
            BindGameplayServices();
            BindWindowService();

            BindShootStateMachineAndStates();
            BindHeroStateMachineAndStates();

            Container.BindInterfacesTo<UpdateService>().AsSingle();
            
            Container.BindInterfacesTo<BootstrapInstaller>()
                .FromInstance(this);
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

        private void BindHeroStateMachineAndStates()
        {
            Container.BindInterfacesTo<HeroStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<HeroInitState>().AsSingle();
        }

        private void BindShootStateMachineAndStates()
        {
            Container.BindInterfacesTo<ShootStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShootState>().AsSingle(); 
            Container.BindInterfacesAndSelfTo<AimShootState>().AsSingle(); 
            Container.BindInterfacesAndSelfTo<MovementState>().AsSingle(); 
            Container.BindInterfacesAndSelfTo<SwitchGunState>().AsSingle(); 
            Container.BindInterfacesAndSelfTo<AimMovementState>().AsSingle(); 
            Container.BindInterfacesAndSelfTo<AimIdleState>().AsSingle(); 
            Container.BindInterfacesAndSelfTo<IdleState>().AsSingle(); 
            Container.BindInterfacesAndSelfTo<ReloadState>().AsSingle();
            Container.BindInterfacesAndSelfTo<IdleFocusState>().AsSingle();

            BindShootTransition();

            Container.BindInterfacesAndSelfTo<CanAimShootCondition>().AsSingle();
            Container.BindInterfacesAndSelfTo<CanReloadCondition>().AsSingle();
            Container.BindInterfacesTo<ConditionalFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovingOnGroundCondition>().AsSingle();
            Container.BindInterfacesAndSelfTo<NeedReloadingCondition>().AsSingle();
            Container.BindInterfacesAndSelfTo<NoMouseButtonInputCondition>().AsSingle();
            Container.BindInterfacesAndSelfTo<OnGroundCondition>().AsSingle();
            Container.BindInterfacesAndSelfTo<IsAimingCondition>().AsSingle();
            Container.BindInterfacesAndSelfTo<HasAxisInputConditional>().AsSingle();
            Container.BindInterfacesAndSelfTo<IsShootingCondition>().AsSingle();
            Container.BindInterfacesAndSelfTo<HasIdleFocusCondition>().AsSingle();
        }

        private void BindShootTransition()
        {
            Container.BindInterfacesAndSelfTo<ReloadTransition>().AsSingle();
            Container.BindInterfacesAndSelfTo<JumpTransition>().AsSingle();
            Container.BindInterfacesAndSelfTo<AimIdleTransition>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovementTransition>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShootTransition>().AsSingle();
            Container.BindInterfacesAndSelfTo<AimShootTransition>().AsSingle();
            Container.BindInterfacesAndSelfTo<IdleTransition>().AsSingle();
            Container.BindInterfacesAndSelfTo<AimMovementTransition>().AsSingle();
            Container.BindInterfacesAndSelfTo<IdleFocusTransition>().AsSingle();
            
            Container.Bind<ITransitionFactory>().To<TransitionFactory>().AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<ITargetSelector>().To<TargetSelector>().AsSingle();
            Container.BindInterfacesTo<TimerService>().AsTransient();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<IDamageService>().To<DamageService>().AsSingle();
            Container.BindInterfacesTo<StatService>().AsSingle();
            Container.BindInterfacesTo<DamageNotifierService>().AsSingle();
            Container.BindInterfacesTo<ShootSwitcherService>().AsSingle();
            Container.Bind<IRaycastService>().To<RaycastService>().AsTransient();
        }

        private void BindAbilityServices()
        {
            Container.BindInterfacesAndSelfTo<AbilityService>().AsSingle();
            Container.BindInterfacesAndSelfTo<AbilityFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<AbilityStaticDataService>().AsSingle();
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
            Container.BindInterfacesTo<ShootService>().AsSingle();
            Container.BindInterfacesTo<ShootFocusService>().AsSingle();
            Container.BindInterfacesTo<ShootReloadService>().AsSingle();
        }

        private void BindHeroServices()
        {
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.BindInterfacesTo<HeroShootHolderService>().AsSingle();
            Container.BindInterfacesTo<HeroService>().AsSingle();
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

        private void BindQuestServices()
        {
            Container.Bind<IQuestService>().To<QuestService>().AsSingle();
            Container.Bind<IQuestFactory>().To<QuestFactory>().AsSingle();
        }

        private void BindAssetManagementServices()
        {
            Container.Bind<IAssetDownloadService>().To<LabeledAssetDownloadService>().AsSingle();
            Container.Bind<IAssetDownloadReporter>().To<AssetDownloadReporter>().AsSingle();
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
            Container.Bind<IQuestStaticDataService>().To<QuestStaticDataService>().AsSingle();
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
            Container.Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .AsSingle();
    }
}