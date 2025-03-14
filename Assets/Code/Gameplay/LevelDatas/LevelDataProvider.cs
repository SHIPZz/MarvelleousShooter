using System.Collections.Generic;
using Code.Gameplay.Enemies.Services;
using UnityEngine;

namespace Code.Gameplay.LevelDatas
{
    public class LevelDataProvider : ILevelDataProvider
    {
         public Transform StartPoint { get;  set; }
         public IReadOnlyList<EnemySpawner> EnemySpawners { get; set; }
    }
}