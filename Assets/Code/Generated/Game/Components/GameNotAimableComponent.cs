//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherNotAimable;

    public static Entitas.IMatcher<GameEntity> NotAimable {
        get {
            if (_matcherNotAimable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NotAimable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNotAimable = matcher;
            }

            return _matcherNotAimable;
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

    static readonly Code.ECS.Gameplay.Features.Shoots.Systems.Aiming.NotAimable notAimableComponent = new Code.ECS.Gameplay.Features.Shoots.Systems.Aiming.NotAimable();

    public bool isNotAimable {
        get { return HasComponent(GameComponentsLookup.NotAimable); }
        set {
            if (value != isNotAimable) {
                var index = GameComponentsLookup.NotAimable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : notAimableComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
