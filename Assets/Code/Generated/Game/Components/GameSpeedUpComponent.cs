//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpeedUp;

    public static Entitas.IMatcher<GameEntity> SpeedUp {
        get {
            if (_matcherSpeedUp == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpeedUp);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpeedUp = matcher;
            }

            return _matcherSpeedUp;
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

    static readonly Code.ECS.Gameplay.Features.Statuses.SpeedUp speedUpComponent = new Code.ECS.Gameplay.Features.Statuses.SpeedUp();

    public bool isSpeedUp {
        get { return HasComponent(GameComponentsLookup.SpeedUp); }
        set {
            if (value != isSpeedUp) {
                var index = GameComponentsLookup.SpeedUp;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : speedUpComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
