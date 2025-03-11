using UnityEngine;

namespace CodeBase.Gameplay.Sounds
{
    public interface ISoundFactory
    {
        Sound Create(SoundTypeId soundTypeId, Transform parent, Vector3 at, Quaternion rotation, bool useOwnPosition = false);
    }
}