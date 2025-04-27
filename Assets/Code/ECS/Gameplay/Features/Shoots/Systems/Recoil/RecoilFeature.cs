using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public sealed class RecoilFeature : Feature
    {
        public RecoilFeature(ISystemFactory systems)
        {
            Add(systems.Create<GenerateRecoilSystem>());
            Add(systems.Create<CalculateRecoilSystem>());
            Add(systems.Create<ApplyHeroRecoilSystem>());
            Add(systems.Create<ResetRecoilSystem>());
        }
    }
}
    