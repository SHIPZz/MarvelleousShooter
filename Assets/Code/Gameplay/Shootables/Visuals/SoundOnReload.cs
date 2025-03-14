using Code.Gameplay.Sounds;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Shootables.Visuals
{
    public class SoundOnReload : MonoBehaviour
    {
        [SerializeField] private ReloadAmmoCount _reloadAmmoCount;
        [SerializeField] private Transform _parent;
        [SerializeField] private Vector3 _position;
        [SerializeField] private SoundTypeId _soundTypeId;

        private ISoundFactory _soundFactory;
        private ISoundService _soundService;

        [Inject]
        private void Construct(ISoundService soundService) => _soundService = soundService;

        private void Start() =>
            _reloadAmmoCount
                .ReloadStartedEvent
                .Subscribe(_ => Do())
                .AddTo(this);

        private void Do() => _soundService.CreateAndPlay(_soundTypeId, _parent, _position, Quaternion.identity);
    }
}