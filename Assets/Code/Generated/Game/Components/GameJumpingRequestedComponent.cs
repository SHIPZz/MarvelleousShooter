//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherJumpingRequested;

    public static Entitas.IMatcher<GameEntity> JumpingRequested {
        get {
            if (_matcherJumpingRequested == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.JumpingRequested);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJumpingRequested = matcher;
            }

            return _matcherJumpingRequested;
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

    static readonly Code.ECS.Gameplay.Features.Movement.Jumping.JumpingRequested jumpingRequestedComponent = new Code.ECS.Gameplay.Features.Movement.Jumping.JumpingRequested();

    public bool isJumpingRequested {
        get { return HasComponent(GameComponentsLookup.JumpingRequested); }
        set {
            if (value != isJumpingRequested) {
                var index = GameComponentsLookup.JumpingRequested;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : jumpingRequestedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
