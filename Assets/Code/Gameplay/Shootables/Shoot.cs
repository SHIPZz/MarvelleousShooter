using System;
using Code.Gameplay.Animations;
using Code.Gameplay.Cameras;
using Code.Gameplay.Common.Damage;
using Code.Gameplay.Common.Services.Raycast;
using Code.Gameplay.Heroes.Enums;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Recoils;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.Visuals;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Shootables
{
    public class Shoot : MonoBehaviour
    {
        public ShootTypeId Id;
        public GunInputTypeId ShowInputKey;

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

        [ShowInInspector] public bool IsShooting { get; private set; }
        
        [ShowInInspector] public bool IsShootingAvailable { get; private set; }

        [field: SerializeField] public float ShootInterval { get; set; }
        [field: SerializeField] public bool NeedAnimationComplete { get; set; }
        [field: SerializeField] public AnimancerAnimatorPlayer ShootAnimator { get; private set; }

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
            IsShooting = false;
            _recoil.ResetRecoil();
            _shootStopEvent?.OnNext(this);
            Debug.Log($"@@@ shooting finished");
        }

        public void StartShooting()
        {
            Debug.Log($"@@@: do shoot");
            IsShooting = true;
            _lastShootTime = Time.time;

            Vector3 direction = _cameraProvider.Camera.transform.forward;
            Vector3 origin = _cameraProvider.Camera.transform.position;

            _raycastService.GetTargetHitsNonAlloc(out RaycastHit[] raycastHits, origin, direction);

            SendEvents(raycastHits);

            _raycastService.ClearRaycastHits();
        }

        public void MarkShootingAvailable(bool isAvailable)
        {
            IsShootingAvailable = isAvailable;
        }

        public void MakeRecoil()
        {
            _recoil.GenerateRecoil();
        }

        private bool CanShoot()
        {
            return Time.time >= _lastShootTime + ShootInterval 
                   && IsShooting
                   && IsShootingAvailable
                   && _onShootAnimationPlayer.AnimationFinished();
        }

        private void SendEvents(RaycastHit[] raycastHits)
        {
            _shootEvent?.OnNext(this);
            _damageDealer.Do(raycastHits.Length, raycastHits);
            _shootHitsEvent?.OnNext(raycastHits);
            IsShooting = true;
        }
    }
}