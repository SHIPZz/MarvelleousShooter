using UnityEngine;

namespace CodeBase.Extensions
{
    public static class ComponentExtensions
    {
        public static T GetComponentAnywhere<T>(this UnityEngine.GameObject obj)
        {
            T component = obj.GetComponent<T>();
            
            if (component != null)
                return component;

            Transform transform = obj.GetComponent<Transform>();

            Transform parent = transform.parent;
            while (parent != null)
            {
                component = parent.GetComponent<T>();
            
                if (component != null)
                    return component;
                
                parent = parent.parent;
            }

            return GetComponentInChildrenRecursive<T>(transform);
        }

        private static T GetComponentInChildrenRecursive<T>(Transform parent)
        {
            foreach (Transform child in parent)
            {
                T component = child.GetComponent<T>();
                if (component != null)
                    return component;
            
                component = GetComponentInChildrenRecursive<T>(child);
                if (component != null)
                    return component;
            }
            
            return default;
        }
    }
}