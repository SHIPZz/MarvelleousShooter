using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Common.Services.Raycast
{
    public class RaycastHitComparer : IComparer<RaycastHit>
    {
        public int Compare(RaycastHit x, RaycastHit y)
        {
            return x.distance.CompareTo(y.distance);
        }
    }
}