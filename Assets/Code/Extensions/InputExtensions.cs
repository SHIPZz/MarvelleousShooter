using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Shoots.Enums;
using UnityEngine;

namespace Code.Extensions
{
    public static class InputExtensions
    {
        private static readonly Dictionary<KeyCode, GunInputTypeId> _weaponSelectByKey = new()
        {
            { KeyCode.Q, GunInputTypeId.Nothing },
            { KeyCode.Alpha1, GunInputTypeId.Main },
            { KeyCode.Alpha2, GunInputTypeId.Second },
            { KeyCode.Alpha3, GunInputTypeId.Knife },
            { KeyCode.Alpha4, GunInputTypeId.Grenade },
            { KeyCode.Alpha5, GunInputTypeId.Syringe },
            { KeyCode.Alpha6, GunInputTypeId.Flashlight },
        };

        public static GunInputTypeId AsShootInput(this KeyCode keyCode)
        {
            return _weaponSelectByKey.GetValueOrDefault(keyCode, GunInputTypeId.None);
        }
    }
}