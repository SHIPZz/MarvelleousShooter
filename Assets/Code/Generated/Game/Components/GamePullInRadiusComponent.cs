//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPullInRadius;

    public static Entitas.IMatcher<GameEntity> PullInRadius {
        get {
            if (_matcherPullInRadius == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PullInRadius);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPullInRadius = matcher;
            }

            return _matcherPullInRadius;
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

    public Code.ECS.Gameplay.Features.Pull.PullInRadius pullInRadius { get { return (Code.ECS.Gameplay.Features.Pull.PullInRadius)GetComponent(GameComponentsLookup.PullInRadius); } }
    public float PullInRadius { get { return pullInRadius.Value; } }
    public bool hasPullInRadius { get { return HasComponent(GameComponentsLookup.PullInRadius); } }

    public GameEntity AddPullInRadius(float newValue) {
        var index = GameComponentsLookup.PullInRadius;
        var component = (Code.ECS.Gameplay.Features.Pull.PullInRadius)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Pull.PullInRadius));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplacePullInRadius(float newValue) {
        var index = GameComponentsLookup.PullInRadius;
        var component = (Code.ECS.Gameplay.Features.Pull.PullInRadius)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Pull.PullInRadius));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemovePullInRadius() {
        RemoveComponent(GameComponentsLookup.PullInRadius);
        return this;
    }
}
