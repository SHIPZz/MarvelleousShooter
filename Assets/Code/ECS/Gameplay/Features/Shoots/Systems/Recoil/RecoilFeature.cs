using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public sealed class RecoilFeature : Feature
    {
        public RecoilFeature(ISystemFactory systems)
        {
            Add(systems.Create<GenerateRecoilSystem>());
            Add(systems.Create<ApplyRecoilSystem>());
            Add(systems.Create<ResetRecoilSystem>());
        }
    }
}
    