using System;
using System.Collections.Generic;
using System.Linq;
using Code.Constant;
using UnityEngine;

namespace Code.UI
{
    public class UIStaticDataService : IUIStaticDataService
    {
        private readonly Dictionary<Type, AbstractWindowBase> _windows;
        private readonly Dictionary<WindowTypeId, AbstractWindowBase> _windowsById;

        public UIStaticDataService()
        {
            _windows = Resources.LoadAll<AbstractWindowBase>(AssetPath.Windows)
                .ToDictionary(x => x.GetType(), x => x);
        
            _windowsById = Resources.LoadAll<AbstractWindowBase>(AssetPath.Windows)
                .ToDictionary(x => x.WindowTypeId, x => x);
        }

        public T GetWindow<T>(Type windowType) where T : AbstractWindowBase
        {
            if (!_windows.TryGetValue(windowType, out AbstractWindowBase windowPrefab))
                throw new Exception();

            return (T)windowPrefab;
        }
    
        public T GetWindow<T>() where T : AbstractWindowBase
        {
            if (!_windows.TryGetValue(typeof(T), out AbstractWindowBase windowPrefab))
                throw new Exception();

            return (T)windowPrefab;
        }
    
        public T GetWindow<T>(WindowTypeId windowTypeId) where T : AbstractWindowBase
        {
            if (!_windowsById.TryGetValue(windowTypeId, out AbstractWindowBase windowPrefab))
                throw new Exception();

            return (T)windowPrefab;
        }
    }
}