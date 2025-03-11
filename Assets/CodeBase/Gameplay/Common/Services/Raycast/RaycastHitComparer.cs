using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Common.Services.Raycast
{
    public class RaycastHitComparer : IComparer<RaycastHit>
    {
        public int Compare(RaycastHit x, RaycastHit y)
        {
            return x.distance.CompareTo(y.distance);
        }
    }
}