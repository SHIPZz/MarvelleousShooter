using CodeBase.Gameplay.Sounds;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Shootables.Visuals
{
    public class SoundOnShoot : MonoBehaviour
    {
        [SerializeField]  private Shoot _shoot;
        [SerializeField]  private Transform _parent;
        [SerializeField]  private Vector3 _position;
        [SerializeField] private SoundTypeId _soundTypeId;
        
        private ISoundService _soundService;

        [Inject]
        private void Construct(ISoundService soundService) => _soundService = soundService;

        private void Start() =>
            _shoot.ShootEvent
                .Subscribe( _ => Do())
                .AddTo(this);

        private void Do() => _soundService.CreateAndPlay(_soundTypeId, _parent, _position, Quaternion.identity);
    }
}