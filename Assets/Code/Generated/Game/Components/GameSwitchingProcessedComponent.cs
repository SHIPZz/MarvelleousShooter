//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSwitchingProcessed;

    public static Entitas.IMatcher<GameEntity> SwitchingProcessed {
        get {
            if (_matcherSwitchingProcessed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SwitchingProcessed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSwitchingProcessed = matcher;
            }

            return _matcherSwitchingProcessed;
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

    static readonly Code.ECS.Gameplay.Features.Shoots.Systems.Switching.SwitchingProcessed switchingProcessedComponent = new Code.ECS.Gameplay.Features.Shoots.Systems.Switching.SwitchingProcessed();

    public bool isSwitchingProcessed {
        get { return HasComponent(GameComponentsLookup.SwitchingProcessed); }
        set {
            if (value != isSwitchingProcessed) {
                var index = GameComponentsLookup.SwitchingProcessed;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : switchingProcessedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
