using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Shootables
{
    public class ReloadAmmoCount : MonoBehaviour
    {
       [SerializeField]  private AmmoCount _ammoCount;

        public float ReloadTime { get; private set; }

        public bool Reloading { get; private set; }

        public bool NoAmmo => _ammoCount.NoAmmo;

        private readonly Subject<Unit> _reloadStartedEvent = new Subject<Unit>();
        private readonly Subject<Unit> _reloadStoppedEvent = new Subject<Unit>();

        public IObservable<Unit> ReloadStartedEvent => _reloadStartedEvent;

        public IObservable<Unit> ReloadStoppedEvent => _reloadStoppedEvent;

        public void SetReloadTime(float reloadTime) => ReloadTime = Mathf.Clamp(ReloadTime + reloadTime,0, float.MaxValue);

        public async UniTask DoAsync(CancellationToken cancellationToken)
        {
            if (Reloading)
                return;
            
            _reloadStartedEvent?.OnNext(Unit.Default);
            Reloading = true;
            await UniTask.WaitForSeconds(ReloadTime, cancellationToken: cancellationToken);

            Reloading = false;
            _reloadStoppedEvent?.OnNext(Unit.Default);
        }
    }
}