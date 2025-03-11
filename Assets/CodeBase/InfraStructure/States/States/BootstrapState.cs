using CodeBase.InfraStructure.AssetManagement_1;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;
using UnityEngine;

namespace CodeBase.InfraStructure.States.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameGameStateMachine;
        private IAssetDownloadService _assetDownloadService;

        public BootstrapState(IGameStateMachine gameGameStateMachine, IAssetDownloadService assetDownloadService)
        {
            _assetDownloadService = assetDownloadService;
            _gameGameStateMachine = gameGameStateMachine;
        }

        public async void Enter()
        {
            await _assetDownloadService.InitializeDownloadDataAsync();

            Debug.Log($"{_assetDownloadService.GetDownloadSizeMb()} - download size");

            if (_assetDownloadService.GetDownloadSizeMb() > 0)
                await _assetDownloadService.UpdateContentAsync();

            _gameGameStateMachine.Enter<LevelLoadState>();
        }

        public void Exit()
        {
            
        }
    }
}