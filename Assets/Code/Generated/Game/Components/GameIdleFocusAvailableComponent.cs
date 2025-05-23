//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherIdleFocusAvailable;

    public static Entitas.IMatcher<GameEntity> IdleFocusAvailable {
        get {
            if (_matcherIdleFocusAvailable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.IdleFocusAvailable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherIdleFocusAvailable = matcher;
            }

            return _matcherIdleFocusAvailable;
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

    static readonly Code.ECS.Gameplay.Features.Movement.IdleFocusAvailable idleFocusAvailableComponent = new Code.ECS.Gameplay.Features.Movement.IdleFocusAvailable();

    public bool isIdleFocusAvailable {
        get { return HasComponent(GameComponentsLookup.IdleFocusAvailable); }
        set {
            if (value != isIdleFocusAvailable) {
                var index = GameComponentsLookup.IdleFocusAvailable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : idleFocusAvailableComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
