using Code.ECS.Gameplay.Features.Statuses.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Statuses
{
    public sealed class StatusFeature : Feature
    {
        public StatusFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<StatusDurationSystem>());
            Add(systemses.Create<PeriodicDamageStatusSystem>());
            Add(systemses.Create<ApplyStatusesOnTargetsSystem>());
            Add(systemses.Create<ApplyFreezeStatusSystem>());
            Add(systemses.Create<ApplyMaxHpIncreaseStatusSystem>());
            Add(systemses.Create<ApplyInvurnableStatusSystem>());
            Add(systemses.Create<ApplySpeedUpStatusSystem>());

            Add(systemses.Create<CleanupUnappliedStatusLinkedChanges>());
            Add(systemses.Create<CleanupUnappliedStatuses>());
        }
    }
}