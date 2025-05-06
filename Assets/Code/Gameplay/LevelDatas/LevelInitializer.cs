using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.LevelDatas
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        public Transform StartPoint;
        
        [Inject] private ILevelDataProvider _levelDataProvider;
        
        public void Initialize()
        {
            _levelDataProvider.StartPoint = StartPoint;

        }
    }
}