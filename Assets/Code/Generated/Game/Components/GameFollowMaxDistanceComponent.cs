//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherFollowMaxDistance;

    public static Entitas.IMatcher<GameEntity> FollowMaxDistance {
        get {
            if (_matcherFollowMaxDistance == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FollowMaxDistance);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFollowMaxDistance = matcher;
            }

            return _matcherFollowMaxDistance;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.ECS.Gameplay.Features.Follow.FollowMaxDistance followMaxDistance { get { return (Code.ECS.Gameplay.Features.Follow.FollowMaxDistance)GetComponent(GameComponentsLookup.FollowMaxDistance); } }
    public float FollowMaxDistance { get { return followMaxDistance.Value; } }
    public bool hasFollowMaxDistance { get { return HasComponent(GameComponentsLookup.FollowMaxDistance); } }

    public GameEntity AddFollowMaxDistance(float newValue) {
        var index = GameComponentsLookup.FollowMaxDistance;
        var component = (Code.ECS.Gameplay.Features.Follow.FollowMaxDistance)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Follow.FollowMaxDistance));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceFollowMaxDistance(float newValue) {
        var index = GameComponentsLookup.FollowMaxDistance;
        var component = (Code.ECS.Gameplay.Features.Follow.FollowMaxDistance)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Follow.FollowMaxDistance));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveFollowMaxDistance() {
        RemoveComponent(GameComponentsLookup.FollowMaxDistance);
        return this;
    }
}
