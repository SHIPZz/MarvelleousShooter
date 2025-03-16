using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.CharacterStats.Systems
{
    public sealed class StatsFeature : Feature
    {
        public StatsFeature(ISystemFactory systemFactory)
        {
            // Add(systemFactory.Create<StatChangeSystem>());
            // Add(systemFactory.Create<ApplySpeedFromStatsSystem>());
            // Add(systemFactory.Create<ApplyMaxHpFromStatsSystem>());
        }
    }
}