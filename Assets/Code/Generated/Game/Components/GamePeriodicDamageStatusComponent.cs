//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPeriodicDamageStatus;

    public static Entitas.IMatcher<GameEntity> PeriodicDamageStatus {
        get {
            if (_matcherPeriodicDamageStatus == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PeriodicDamageStatus);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPeriodicDamageStatus = matcher;
            }

            return _matcherPeriodicDamageStatus;
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

    static readonly Code.ECS.Gameplay.Features.Statuses.PeriodicDamageStatus periodicDamageStatusComponent = new Code.ECS.Gameplay.Features.Statuses.PeriodicDamageStatus();

    public bool isPeriodicDamageStatus {
        get { return HasComponent(GameComponentsLookup.PeriodicDamageStatus); }
        set {
            if (value != isPeriodicDamageStatus) {
                var index = GameComponentsLookup.PeriodicDamageStatus;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : periodicDamageStatusComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
