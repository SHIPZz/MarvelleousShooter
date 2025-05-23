//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherJumpForce;

    public static Entitas.IMatcher<GameEntity> JumpForce {
        get {
            if (_matcherJumpForce == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.JumpForce);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJumpForce = matcher;
            }

            return _matcherJumpForce;
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

    public Code.ECS.Gameplay.Features.Movement.JumpForce jumpForce { get { return (Code.ECS.Gameplay.Features.Movement.JumpForce)GetComponent(GameComponentsLookup.JumpForce); } }
    public float JumpForce { get { return jumpForce.Value; } }
    public bool hasJumpForce { get { return HasComponent(GameComponentsLookup.JumpForce); } }

    public GameEntity AddJumpForce(float newValue) {
        var index = GameComponentsLookup.JumpForce;
        var component = (Code.ECS.Gameplay.Features.Movement.JumpForce)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Movement.JumpForce));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceJumpForce(float newValue) {
        var index = GameComponentsLookup.JumpForce;
        var component = (Code.ECS.Gameplay.Features.Movement.JumpForce)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Movement.JumpForce));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveJumpForce() {
        RemoveComponent(GameComponentsLookup.JumpForce);
        return this;
    }
}
