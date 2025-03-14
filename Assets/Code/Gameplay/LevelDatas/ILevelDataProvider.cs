using System.Collections.Generic;
using Code.Gameplay.Enemies.Services;
using UnityEngine;

namespace Code.Gameplay.LevelDatas
{
    public interface ILevelDataProvider
    {
        Transform StartPoint { get; set; }
        IReadOnlyList<EnemySpawner> EnemySpawners { get; set; }
    }
}