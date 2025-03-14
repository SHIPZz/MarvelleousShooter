using UniRx;
using UnityEngine;

namespace Code.Gameplay.Shootables.Visuals
{
    public class RecoilOnShoot : MonoBehaviour
    {
        [SerializeField] private Shoot _shoot;

        private void Start()
        {
            _shoot.ShootEvent
                .Subscribe(_ => _shoot.MakeRecoil())
                .AddTo(this);
        }
    }
}