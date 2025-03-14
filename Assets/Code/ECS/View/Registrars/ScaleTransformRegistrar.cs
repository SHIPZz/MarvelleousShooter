using UnityEngine;

namespace Code.ECS.View.Registrars
{
    public class ScaleTransformRegistrar : EntityComponentRegistrar
    {
        public Transform TargetTransform;
    
        public override void RegisterComponents()
        {
            // Entity.AddScaleTransform(TargetTransform);
        }

        public override void UnregisterComponents()
        {
            // if (Entity.hasScaleTransform)
                // Entity.RemoveScaleTransform();
        }
    }
}