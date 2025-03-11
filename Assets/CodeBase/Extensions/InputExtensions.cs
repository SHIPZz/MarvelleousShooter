using System.Collections.Generic;
using CodeBase.Gameplay.Heroes.Enums;
using UnityEngine;

namespace CodeBase.Extensions
{
    public static class InputExtensions
    {
        private static readonly Dictionary<KeyCode, ShootInputTypeId> _weaponSelectByKey = new()
        {
            { KeyCode.Alpha0, ShootInputTypeId.Nothing },
            { KeyCode.Alpha1, ShootInputTypeId.Main },
            { KeyCode.Alpha2, ShootInputTypeId.Second },
            { KeyCode.Alpha3, ShootInputTypeId.Knife },
            { KeyCode.Alpha4, ShootInputTypeId.Grenade },
            { KeyCode.Alpha5, ShootInputTypeId.Syringe },
            { KeyCode.Alpha6, ShootInputTypeId.Flashlight },
        };

        public static ShootInputTypeId AsShootInput(this KeyCode keyCode)
        {
            return _weaponSelectByKey.GetValueOrDefault(keyCode, ShootInputTypeId.None);
        }
    }
}