using UnityEngine;

namespace Code.Gameplay.Common
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