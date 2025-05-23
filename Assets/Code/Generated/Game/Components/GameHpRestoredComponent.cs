//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHpRestored;

    public static Entitas.IMatcher<GameEntity> HpRestored {
        get {
            if (_matcherHpRestored == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HpRestored);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHpRestored = matcher;
            }

            return _matcherHpRestored;
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

    static readonly Code.ECS.Gameplay.Features.Lifetime.HpRestored hpRestoredComponent = new Code.ECS.Gameplay.Features.Lifetime.HpRestored();

    public bool isHpRestored {
        get { return HasComponent(GameComponentsLookup.HpRestored); }
        set {
            if (value != isHpRestored) {
                var index = GameComponentsLookup.HpRestored;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : hpRestoredComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
