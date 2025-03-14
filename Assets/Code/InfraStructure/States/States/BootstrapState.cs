using Code.ECS.Infrastructure.StateInfrastructure;
using Code.ECS.Infrastructure.StateMachine;
using Code.InfraStructure.AssetManagement_1;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine;
using UnityEngine;

namespace Code.InfraStructure.States.States
{
    public class BootstrapState : SimpleState
    {
        private readonly IGameStateMachine _gameGameStateMachine;

        public BootstrapState(IGameStateMachine gameGameStateMachine)
        {
            _gameGameStateMachine = gameGameStateMachine;
        }

        public override void Enter()
        {
            // await _assetDownloadService.InitializeDownloadDataAsync();
            //
            // Debug.Log($"{_assetDownloadService.GetDownloadSizeMb()} - download size");
            //
            // if (_assetDownloadService.GetDownloadSizeMb() > 0)
            //     await _assetDownloadService.UpdateContentAsync();

            _gameGameStateMachine.Enter<LevelLoadState>();
        }

        public void Exit()
        {
            
        }
    }
}