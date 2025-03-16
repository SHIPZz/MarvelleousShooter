using System;
using System.Collections.Generic;

namespace Code.ECS.Gameplay.Features.Statuses.Indexing
{
    public struct StatusKey
    {
        public readonly int TargetId;
        public readonly StatusTypeId TypeId;

        public StatusKey(int targetId, StatusTypeId typeId)
        {
            TargetId = targetId;
            TypeId = typeId;
        }
    }
    
    public class StatusKeyEqualityComparer : IEqualityComparer<StatusKey>
    {
        public bool Equals(StatusKey x, StatusKey y)
        {
            return x.TargetId == y.TargetId && x.TypeId == y.TypeId;
        }

        public int GetHashCode(StatusKey obj)
        {
            return HashCode.Combine(obj.TargetId, (int)obj.TypeId);
        }
    }
}