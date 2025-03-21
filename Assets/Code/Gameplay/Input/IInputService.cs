using System;
using Code.Gameplay.Heroes.Enums;
using UniRx;
using UnityEngine;

namespace Code.Gameplay.Input
{
  public interface IInputService
  {
    float GetVerticalAxis();
    float GetHorizontalAxis();
    bool HasAxisInput();
    
    bool GetLeftMouseButtonDown();
    Vector2 GetScreenMousePosition();
    Vector2 GetWorldMousePosition();
    bool GetLeftMouseButtonUp();
    float GetMouseX();
    float GetMouseY();
    bool IsShooting();
    bool ReloadPressed { get; }
    IObservable<Unit> OnLeftMouseButtonDown { get; }
    IObservable<Unit> OnLeftMouseButtonUp { get; }
    IObservable<Unit> OnRightMouseButtonDown { get; }
    IObservable<Unit> OnRightMouseButtonUp { get; }
    IObservable<Unit> OnReloadPressed { get; }
    IObservable<bool> OnHasAxisAxisInput { get; }
    IObservable<GunInputTypeId> OnGunSelected { get; }
    IObservable<Unit> OnGunFocusRequested { get;  }
    bool IsRunningPressed();
    bool IsAiming();
    bool GetRightMouseButtonDown();
    bool GetRightMouseButtonUp();
    bool HasMouseAxis();
    Vector3 GetAxis();
  }
}