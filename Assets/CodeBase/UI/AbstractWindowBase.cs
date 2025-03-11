using UnityEngine;

namespace CodeBase.UI
{
    public abstract class AbstractWindowBase : MonoBehaviour
    {
        public WindowTypeId WindowTypeId;
    
        public virtual void Open()
        {
        
        }

        public virtual void Close()
        {
        
        }
    }
}