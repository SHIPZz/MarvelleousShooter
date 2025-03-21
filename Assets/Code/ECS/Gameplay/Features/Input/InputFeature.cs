using Code.ECS.Gameplay.Features.Input.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Input
{
    public sealed class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systems)
        {
            Add(systems.Create<EmitShootInputSystem>());
            Add(systems.Create<EmitAimInputSystem>());
            Add(systems.Create<EmitAxisInputSystem>());
            Add(systems.Create<EmitReloadInputSystem>());
            Add(systems.Create<EmitRunningInputSystem>());
            Add(systems.Create<EmitChangeGunInputSystem>());
            
            Add(systems.Create<DisableAimInputsOnGunActionsSystem>());
            Add(systems.Create<DisableShootInputsOnGunActionsSystem>());
            Add(systems.Create<DisableReloadInputOnGunActionsSystem>());
        }
    }
}