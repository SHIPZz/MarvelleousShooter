using System;
using Code.ECS.Gameplay.Features.Shoots.Enums;
using UnityEngine;

namespace Code.ECS.Common.Services
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
    IObservable<GunInputTypeId> GunSelectedEvent { get; }
    bool IsRunningPressed();
    bool IsAiming();
    bool GetRightMouseButtonDown();
    bool GetRightMouseButtonUp();
    bool HasMouseAxis();
    Vector3 GetAxis();
    bool IsJumpButtonPressed();
    bool IsDoubleShooting();
    bool IdleFocusPressed();
  }
}