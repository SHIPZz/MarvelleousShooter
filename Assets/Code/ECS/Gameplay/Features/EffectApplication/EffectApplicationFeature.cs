using Code.ECS.Gameplay.Features.EffectApplication.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.EffectApplication
{
    public sealed class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<ApplyEffectsOnTargetsSystem>());
        }
    }
}