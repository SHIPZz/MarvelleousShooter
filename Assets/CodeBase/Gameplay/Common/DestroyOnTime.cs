using System;
using UnityEngine;

namespace CodeBase.Gameplay.Common
{
    public class DestroyOnTime : MonoBehaviour
    {
        public float Time;

        private void Start()
        {
            Destroy(gameObject, Time);
        }
    }
}