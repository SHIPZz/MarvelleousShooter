using System.Collections.Generic;
using CodeBase.Gameplay.Enemies;
using CodeBase.Gameplay.Enemies.Services;
using UnityEngine;

namespace CodeBase.Gameplay.LevelDatas
{
    public interface ILevelDataProvider
    {
        Transform StartPoint { get; set; }
        IReadOnlyList<EnemySpawner> EnemySpawners { get; set; }
    }
}