using System;

namespace CodeBase.Gameplay.Resource
{
    [Serializable]
    public class ResourceData
    {
        public ResourceTypeId ResourceTypeId;
        public int Count;

        public ResourceData(ResourceTypeId resourceTypeId, int count)
        {
            ResourceTypeId = resourceTypeId;
            Count = count;
        }
    }

    public enum ResourceTypeId
    {
        Unknown = 0,
        Money = 1,
        Crystal = 2,
        Experience = 3,
    }
}