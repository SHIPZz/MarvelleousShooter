//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherVampirism;

    public static Entitas.IMatcher<GameEntity> Vampirism {
        get {
            if (_matcherVampirism == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Vampirism);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVampirism = matcher;
            }

            return _matcherVampirism;
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

    static readonly Code.ECS.Gameplay.Features.Statuses.Vampirism vampirismComponent = new Code.ECS.Gameplay.Features.Statuses.Vampirism();

    public bool isVampirism {
        get { return HasComponent(GameComponentsLookup.Vampirism); }
        set {
            if (value != isVampirism) {
                var index = GameComponentsLookup.Vampirism;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : vampirismComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
