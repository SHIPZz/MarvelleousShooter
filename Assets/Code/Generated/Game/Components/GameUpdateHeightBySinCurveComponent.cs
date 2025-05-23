//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherUpdateHeightBySinCurve;

    public static Entitas.IMatcher<GameEntity> UpdateHeightBySinCurve {
        get {
            if (_matcherUpdateHeightBySinCurve == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UpdateHeightBySinCurve);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUpdateHeightBySinCurve = matcher;
            }

            return _matcherUpdateHeightBySinCurve;
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

    static readonly Code.ECS.Gameplay.Features.Movement.UpdateHeightBySinCurve updateHeightBySinCurveComponent = new Code.ECS.Gameplay.Features.Movement.UpdateHeightBySinCurve();

    public bool isUpdateHeightBySinCurve {
        get { return HasComponent(GameComponentsLookup.UpdateHeightBySinCurve); }
        set {
            if (value != isUpdateHeightBySinCurve) {
                var index = GameComponentsLookup.UpdateHeightBySinCurve;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : updateHeightBySinCurveComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
