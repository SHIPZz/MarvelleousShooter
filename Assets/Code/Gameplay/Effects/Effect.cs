using UnityEngine;

namespace Code.Gameplay.Effects
{
    public class Effect : MonoBehaviour
    {
        public EffectTypeId EffectTypeId;
        public float DestroyTime = 1f;

        [SerializeField] private ParticleSystem _effect;

        public void Play()
        {
            _effect.Play();
            Destroy(gameObject, DestroyTime);
        }
    }
}