using System.Collections.Generic;
using Code.Gameplay.Enemies.Services;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.LevelDatas
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        public Transform StartPoint;
        public List<EnemySpawner> EnemySpawners;
        
        [Inject] private ILevelDataProvider _levelDataProvider;
        
        public void Initialize()
        {
            _levelDataProvider.StartPoint = StartPoint;
            _levelDataProvider.EnemySpawners = EnemySpawners;

        }
    }
}