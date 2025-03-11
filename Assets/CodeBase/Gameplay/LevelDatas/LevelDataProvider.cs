using System.Collections.Generic;
using CodeBase.Gameplay.Enemies;
using CodeBase.Gameplay.Enemies.Services;
using UnityEngine;

namespace CodeBase.Gameplay.LevelDatas
{
    public class LevelDataProvider : ILevelDataProvider
    {
         public Transform StartPoint { get;  set; }
         public IReadOnlyList<EnemySpawner> EnemySpawners { get; set; }
    }
}