using System;
using CodeBase.Extensions;
using CodeBase.Gameplay.Heroes.Enums;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using Zenject;

namespace CodeBase.Gameplay.Input
{
    public class StandaloneInputService : IInputService, ITickable
    {
        private Camera _mainCamera;
        private Vector3 _screenPosition;

        private readonly Subject<ShootInputTypeId> _shootSelected = new Subject<ShootInputTypeId>();

        private readonly Subject<Unit> _leftMouseButtonDown = new Subject<Unit>();
        private readonly Subject<Unit> _leftMouseButtonUp = new Subject<Unit>();
        private readonly Subject<Unit> _rightMouseButtonDown = new Subject<Unit>();
        private readonly Subject<Unit> _rightMouseButtonUp = new Subject<Unit>();
        private readonly Subject<Unit> _reloadPressed = new Subject<Unit>();
        private readonly Subject<Unit> _gunFocusRequested = new Subject<Unit>();
        private readonly Subject<bool> _axisInput = new Subject<bool>();

        public IObservable<Unit> OnLeftMouseButtonDown => _leftMouseButtonDown;
        public IObservable<Unit> OnLeftMouseButtonUp => _leftMouseButtonUp;
        public IObservable<Unit> OnRightMouseButtonDown => _rightMouseButtonDown;
        public IObservable<Unit> OnRightMouseButtonUp => _rightMouseButtonUp;
        public IObservable<Unit> OnReloadPressed => _reloadPressed;
        public IObservable<bool> OnHasAxisAxisInput => _axisInput;
        
        public IObservable<Unit> OnGunFocusRequested => _gunFocusRequested;

        public IObservable<ShootInputTypeId> OnShootSelected => _shootSelected;

        public Camera CameraMain
        {
            get
            {
                if (_mainCamera == null && Camera.main != null)
                    _mainCamera = Camera.main;

                return _mainCamera;
            }
        }

        public void Tick()
        {
            _axisInput?.OnNext(HasAxisInput());

            if (ReloadPressed)
                _reloadPressed?.OnNext(Unit.Default);
            
            if(GunFocusPressed)
                _gunFocusRequested?.OnNext(default);

            CheckLeftMouseButton();
            CheckRightMouseButton();

            ProcessShootInputEvents();
        }

        public Vector2 GetScreenMousePosition() =>
            CameraMain ? (Vector2)UnityEngine.Input.mousePosition : new Vector2();

        public Vector2 GetWorldMousePosition()
        {
            if (CameraMain == null)
                return Vector2.zero;

            _screenPosition.x = UnityEngine.Input.mousePosition.x;
            _screenPosition.y = UnityEngine.Input.mousePosition.y;
            return CameraMain.ScreenToWorldPoint(_screenPosition);
        }

        public bool HasAxisInput() => GetHorizontalAxis() != 0 || GetVerticalAxis() != 0;


        public float GetVerticalAxis() => UnityEngine.Input.GetAxis("Vertical");

        public float GetHorizontalAxis() => UnityEngine.Input.GetAxis("Horizontal");

        public float GetMouseX() => UnityEngine.Input.GetAxis("Mouse X");

        public float GetMouseY() => UnityEngine.Input.GetAxis("Mouse Y");

        public bool HasMouseAxis() => GetMouseX() != 0 || GetMouseY() != 0;

        public bool IsRunningPressed() => UnityEngine.Input.GetKey(KeyCode.LeftShift);

        public bool IsShooting() =>
            UnityEngine.Input.GetMouseButton(0) 
            && !EventSystem.current.IsPointerOverGameObject();

        public bool IsAiming() =>
            UnityEngine.Input.GetMouseButton(1);


        public bool GetRightMouseButtonDown() => UnityEngine.Input.GetMouseButtonDown(1);

        public bool GetRightMouseButtonUp() => UnityEngine.Input.GetMouseButtonUp(1);

        public bool ReloadPressed => UnityEngine.Input.GetKey(KeyCode.R);

        public bool GetLeftMouseButtonDown() =>
            UnityEngine.Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();

        public bool GetLeftMouseButtonUp() =>
            UnityEngine.Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject();

        private void CheckLeftMouseButton()
        {
            if (GetLeftMouseButtonDown())
            {
                _leftMouseButtonDown.OnNext(Unit.Default);
            }

            if (GetLeftMouseButtonUp())
            {
                _leftMouseButtonUp.OnNext(Unit.Default);
            }
        }

        private void CheckRightMouseButton()
        {
            if (GetRightMouseButtonDown())
            {
                _rightMouseButtonDown.OnNext(Unit.Default);
            }

            if (GetRightMouseButtonUp())
            {
                _rightMouseButtonUp.OnNext(Unit.Default);
            }
        }

        private void ProcessShootInputEvents()
        {
            SendShootInputEventIfKeyDown(KeyCode.Alpha0);
            SendShootInputEventIfKeyDown(KeyCode.Alpha1);
            SendShootInputEventIfKeyDown(KeyCode.Alpha2);
            SendShootInputEventIfKeyDown(KeyCode.Alpha3);
            SendShootInputEventIfKeyDown(KeyCode.Alpha4);
            SendShootInputEventIfKeyDown(KeyCode.Alpha5);
            SendShootInputEventIfKeyDown(KeyCode.Alpha6);
        }

        private void SendShootInputEventIfKeyDown(KeyCode keyCode)
        {
            if (UnityEngine.Input.GetKeyDown(keyCode))
            {
                ShootInputTypeId shootInputTypeId = keyCode.AsShootInput();

                if (shootInputTypeId != ShootInputTypeId.None)
                    _shootSelected?.OnNext(shootInputTypeId);
            }
        }

        private static bool GunFocusPressed => UnityEngine.Input.GetKey(KeyCode.F);
    }
}