using UnityEngine;

namespace CodeBase.Gameplay.Sounds
{
    public interface ISoundService
    {
        void CreateAndPlay(SoundTypeId soundTypeId, Transform parent, Vector3 at, Quaternion rotation);
    }

    public class SoundService : ISoundService
    {
        private readonly ISoundFactory _soundFactory;

        public SoundService(ISoundFactory soundFactory)
        {
            _soundFactory = soundFactory;
        }

        public void CreateAndPlay(SoundTypeId soundTypeId, Transform parent, Vector3 at, Quaternion rotation)
        {
            _soundFactory.Create(soundTypeId, parent, at, rotation).Play();
        }
    }

}

    