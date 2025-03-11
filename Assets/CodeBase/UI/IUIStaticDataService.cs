using System;

namespace CodeBase.UI
{
    public interface IUIStaticDataService
    {
        T GetWindow<T>() where T : AbstractWindowBase;
        T GetWindow<T>(WindowTypeId windowTypeId) where T : AbstractWindowBase;
        T GetWindow<T>(Type windowType) where T : AbstractWindowBase;
    }
}