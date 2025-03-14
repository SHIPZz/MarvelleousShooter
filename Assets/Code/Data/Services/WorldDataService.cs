using Code.SaveData;
using UnityEngine;

namespace Code.Data.Services
{
    public interface IWorldDataService
    {
        WorldData Get();
        void Save(WorldData worldData);
        void Reset();
    }

    public class WorldDataService : IWorldDataService
    {
        private string _key;
        private WorldData _worldData;

        public WorldData Get()
        {
            return _worldData ??= JsonUtility.FromJson<WorldData>(_key) ?? new WorldData();
        }

        public void Save(WorldData worldData)
        {
            _worldData = worldData;
            _key = JsonUtility.ToJson(worldData);
        }

        public void Reset()
        {
            _worldData = null;
            _key = null;
        }
    }
}