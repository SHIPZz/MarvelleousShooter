using System;
using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Common.Damage;
using CodeBase.Gameplay.Common.Services.Raycast;
using CodeBase.Gameplay.Heroes.Enums;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Recoils;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.Visuals;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Shootables
{
    public class Shoot : MonoBehaviour
    {
        public ShootTypeId Id;
        public ShootInputTypeId ShowInputKey;

        private readonly Subject<Shoot> _shootEvent = new Subject<Shoot>();
        private readonly Subject<RaycastHit[]> _shootHitsEvent = new Subject<RaycastHit[]>();
        private readonly Subject<Shoot> _shootStopEvent = new Subject<Shoot>();

        [SerializeField] private Recoil _recoil;
        [SerializeField] private DamageDealer _damageDealer;

        [Inject] private IShootService _shootService;
        [Inject] private IInputService _inputService;
        [Inject] private ICameraProvider _cameraProvider;
        [Inject] private IRaycastService _raycastService;

        private float _lastShootTime = 0;
        
        private OnShootAnimationPlayer _onShootAnimationPlayer;

        [ShowInInspector] public bool IsActive { get; private set; }

        [field: SerializeField] public float ShootInterval { get; set; }
        [field: SerializeField] public bool NeedAnimationComplete { get; set; }
        [field: SerializeField] public ShootAnimator ShootAnimator { get; private set; }

        public IObservable<Shoot> ShootEvent => _shootEvent;
        public IObservable<Shoot> ShootStopEvent => _shootStopEvent;
        public IObservable<RaycastHit[]> ShootWithHitsEvent => _shootHitsEvent;


        private void Update()
        {
            if (CanShoot())
                StartShooting();
        }

        private void OnDestroy()
        {
            _shootEvent?.Dispose();
            _shootStopEvent?.Dispose();
        }

        public void Init(float shootDistance, LayerMask layerMask)
        {
            _raycastService.Init(shootDistance, layerMask);
            _onShootAnimationPlayer = GetComponent<OnShootAnimationPlayer>();
        }

        public void StopShooting()
        {
            MarkShootingActive(false);
            _recoil.ResetRecoil();
            _shootStopEvent?.OnNext(this);
            Debug.Log($"@@@ shooting anim finished");
        }

        public void StartShooting()
        {
            Debug.Log($"@@@: do shoot");
            MarkShootingActive(true);
            _lastShootTime = Time.time;

            Vector3 direction = _cameraProvider.Camera.transform.forward;
            Vector3 origin = _cameraProvider.Camera.transform.position;

            _raycastService.GetTargetHitsNonAlloc(out RaycastHit[] raycastHits, origin, direction);

            SendEvents(raycastHits);

            _raycastService.ClearRaycastHits();
        }

        public void MarkShootingActive(bool isAvailable) => IsActive = isAvailable;

        public void MakeRecoil()
        {
            _recoil.GenerateRecoil();
        }

        private bool CanShoot()
        {
            return Time.time >= _lastShootTime + ShootInterval 
                   && IsActive
                   && _onShootAnimationPlayer.AnimationFinished();
        }

        private void SendEvents(RaycastHit[] raycastHits)
        {
            _shootEvent?.OnNext(this);
            _damageDealer.Do(raycastHits.Length, raycastHits);
            _shootHitsEvent?.OnNext(raycastHits);
            IsActive = true;
        }
    }
}