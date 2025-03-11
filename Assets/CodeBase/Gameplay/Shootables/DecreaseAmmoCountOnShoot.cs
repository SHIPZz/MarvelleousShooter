using System;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Shootables
{
    public class DecreaseAmmoCountOnShoot : MonoBehaviour
    {
        [SerializeField] private Shoot _shoot;
        [SerializeField] private AmmoCount _ammoCount;

        private void Start()
        {
            _shoot
                .ShootEvent
                .Subscribe(_ => _ammoCount.Decrease(1))
                .AddTo(this);
        }
    }
}