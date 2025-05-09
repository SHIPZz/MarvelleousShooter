using Code.ECS.Gameplay.Features.Input.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Input
{
    public sealed class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systems)
        {
            Add(systems.Create<EmitMouseAxisInputSystem>());
            Add(systems.Create<AllowDoubleShootingInputSystem>());

            Add(systems.Create<DisableAimInputsOnGunActionsSystem>());
            Add(systems.Create<DisableShootInputsOnGunActionsSystem>());
            Add(systems.Create<DisableReloadInputOnGunActionsSystem>());
            Add(systems.Create<SetActiveMovementInputOnGroundSystem>());

            Add(systems.Create<EmitShootInputSystem>());
            Add(systems.Create<EmitJumpingInputSystem>());
            Add(systems.Create<EmitAimInputSystem>());
            Add(systems.Create<EmitAxisInputSystem>());
            Add(systems.Create<EmitIdleFocusInputSystem>());
            Add(systems.Create<EmitReloadInputSystem>());
            Add(systems.Create<EmitDoubleShootingInputSystem>());
            Add(systems.Create<EmitRunningInputSystem>());
            Add(systems.Create<EmitChangeGunInputSystem>());
        }
    }
}