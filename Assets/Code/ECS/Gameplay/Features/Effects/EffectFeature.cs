using Code.ECS.Gameplay.Features.Effects.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Effects
{
    public sealed class EffectFeature : Feature
    {
        public EffectFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<RemoveEffectsWithoutTargetsSystem>());
            
            Add(systemFactory.Create<ProcessHealEffectSystem>());
            Add(systemFactory.Create<ProcessDamageEffectSystem>());
            Add(systemFactory.Create<CleanupProcessedEffectsSystem>());
        }
    }
}