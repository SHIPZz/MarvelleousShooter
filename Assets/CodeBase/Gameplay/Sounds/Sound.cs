using UnityEngine;

namespace CodeBase.Gameplay.Sounds
{
    public class Sound : MonoBehaviour
    {
        public SoundTypeId SoundTypeId;
        
        [SerializeField] private AudioSource _audioSource;

        public void Play()
        {
            _audioSource.Play();
        }
    }
}