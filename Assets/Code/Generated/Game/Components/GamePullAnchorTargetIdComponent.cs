//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPullAnchorTargetId;

    public static Entitas.IMatcher<GameEntity> PullAnchorTargetId {
        get {
            if (_matcherPullAnchorTargetId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PullAnchorTargetId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPullAnchorTargetId = matcher;
            }

            return _matcherPullAnchorTargetId;
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

    public Code.ECS.Gameplay.Features.Pull.PullAnchorTargetId pullAnchorTargetId { get { return (Code.ECS.Gameplay.Features.Pull.PullAnchorTargetId)GetComponent(GameComponentsLookup.PullAnchorTargetId); } }
    public int PullAnchorTargetId { get { return pullAnchorTargetId.Value; } }
    public bool hasPullAnchorTargetId { get { return HasComponent(GameComponentsLookup.PullAnchorTargetId); } }

    public GameEntity AddPullAnchorTargetId(int newValue) {
        var index = GameComponentsLookup.PullAnchorTargetId;
        var component = (Code.ECS.Gameplay.Features.Pull.PullAnchorTargetId)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Pull.PullAnchorTargetId));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplacePullAnchorTargetId(int newValue) {
        var index = GameComponentsLookup.PullAnchorTargetId;
        var component = (Code.ECS.Gameplay.Features.Pull.PullAnchorTargetId)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Pull.PullAnchorTargetId));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemovePullAnchorTargetId() {
        RemoveComponent(GameComponentsLookup.PullAnchorTargetId);
        return this;
    }
}
