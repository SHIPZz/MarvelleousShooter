namespace Code.ECS.View.Registrars
{
    public class GroundDetectionTransformRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity.AddGroundDetectionTransform(transform);
        }

        public override void UnregisterComponents()
        {
            if (Entity.GroundDetectionTransform)
                Entity.RemoveGroundDetectionTransform();
        }
    }
}