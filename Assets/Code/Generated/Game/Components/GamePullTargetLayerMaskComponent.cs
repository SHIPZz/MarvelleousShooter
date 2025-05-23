//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPullTargetLayerMask;

    public static Entitas.IMatcher<GameEntity> PullTargetLayerMask {
        get {
            if (_matcherPullTargetLayerMask == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PullTargetLayerMask);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPullTargetLayerMask = matcher;
            }

            return _matcherPullTargetLayerMask;
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

    public Code.ECS.Gameplay.Features.Pull.PullTargetLayerMask pullTargetLayerMask { get { return (Code.ECS.Gameplay.Features.Pull.PullTargetLayerMask)GetComponent(GameComponentsLookup.PullTargetLayerMask); } }
    public int PullTargetLayerMask { get { return pullTargetLayerMask.Value; } }
    public bool hasPullTargetLayerMask { get { return HasComponent(GameComponentsLookup.PullTargetLayerMask); } }

    public GameEntity AddPullTargetLayerMask(int newValue) {
        var index = GameComponentsLookup.PullTargetLayerMask;
        var component = (Code.ECS.Gameplay.Features.Pull.PullTargetLayerMask)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Pull.PullTargetLayerMask));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplacePullTargetLayerMask(int newValue) {
        var index = GameComponentsLookup.PullTargetLayerMask;
        var component = (Code.ECS.Gameplay.Features.Pull.PullTargetLayerMask)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Pull.PullTargetLayerMask));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemovePullTargetLayerMask() {
        RemoveComponent(GameComponentsLookup.PullTargetLayerMask);
        return this;
    }
}
