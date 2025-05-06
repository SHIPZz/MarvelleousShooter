using UnityEngine;

namespace Code.Gameplay.LevelDatas
{
    public interface ILevelDataProvider
    {
        Transform StartPoint { get; set; }
    }
}