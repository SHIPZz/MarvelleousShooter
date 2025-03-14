using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Input
{
    public sealed class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systems)
        {
            Add(systems.Create<EmitShootInputSystem>());
        }
    }
}