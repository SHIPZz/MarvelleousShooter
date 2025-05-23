//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherOrbitPhase;

    public static Entitas.IMatcher<GameEntity> OrbitPhase {
        get {
            if (_matcherOrbitPhase == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.OrbitPhase);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOrbitPhase = matcher;
            }

            return _matcherOrbitPhase;
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

    public Code.ECS.Gameplay.Features.Movement.OrbitPhase orbitPhase { get { return (Code.ECS.Gameplay.Features.Movement.OrbitPhase)GetComponent(GameComponentsLookup.OrbitPhase); } }
    public float OrbitPhase { get { return orbitPhase.Value; } }
    public bool hasOrbitPhase { get { return HasComponent(GameComponentsLookup.OrbitPhase); } }

    public GameEntity AddOrbitPhase(float newValue) {
        var index = GameComponentsLookup.OrbitPhase;
        var component = (Code.ECS.Gameplay.Features.Movement.OrbitPhase)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Movement.OrbitPhase));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceOrbitPhase(float newValue) {
        var index = GameComponentsLookup.OrbitPhase;
        var component = (Code.ECS.Gameplay.Features.Movement.OrbitPhase)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Movement.OrbitPhase));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveOrbitPhase() {
        RemoveComponent(GameComponentsLookup.OrbitPhase);
        return this;
    }
}
