using Code.ECS.Infrastructure.StateInfrastructure;
using Code.ECS.Infrastructure.StateMachine;
using Code.InfraStructure.Loading;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine;

namespace Code.InfraStructure.States.States
{
    public class LevelLoadState : SimpleState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LevelLoadState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public override void Enter()
        {
            _sceneLoader.LoadScene(Scenes.Game, () => _gameStateMachine.Enter<GameState>());
        }

        protected override void Exit()
        {
        }
    }
}