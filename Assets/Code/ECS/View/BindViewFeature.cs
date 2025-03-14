using Code.ECS.Systems;
using Code.ECS.View.Systems;

namespace Code.ECS.View
{
    public sealed class BindViewFeature : Feature
    {
        public BindViewFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<BindEntityViewFromPathSystem>());
            Add(systemFactory.Create<BindEntityViewFromViewPrefabSystem>());
        }
    }
}