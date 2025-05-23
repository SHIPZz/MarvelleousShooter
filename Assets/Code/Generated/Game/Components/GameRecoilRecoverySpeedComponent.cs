//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRecoilRecoverySpeed;

    public static Entitas.IMatcher<GameEntity> RecoilRecoverySpeed {
        get {
            if (_matcherRecoilRecoverySpeed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RecoilRecoverySpeed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRecoilRecoverySpeed = matcher;
            }

            return _matcherRecoilRecoverySpeed;
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

    public Code.ECS.Gameplay.Features.Shoots.Systems.Recoil.RecoilRecoverySpeed recoilRecoverySpeed { get { return (Code.ECS.Gameplay.Features.Shoots.Systems.Recoil.RecoilRecoverySpeed)GetComponent(GameComponentsLookup.RecoilRecoverySpeed); } }
    public float RecoilRecoverySpeed { get { return recoilRecoverySpeed.Value; } }
    public bool hasRecoilRecoverySpeed { get { return HasComponent(GameComponentsLookup.RecoilRecoverySpeed); } }

    public GameEntity AddRecoilRecoverySpeed(float newValue) {
        var index = GameComponentsLookup.RecoilRecoverySpeed;
        var component = (Code.ECS.Gameplay.Features.Shoots.Systems.Recoil.RecoilRecoverySpeed)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Shoots.Systems.Recoil.RecoilRecoverySpeed));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceRecoilRecoverySpeed(float newValue) {
        var index = GameComponentsLookup.RecoilRecoverySpeed;
        var component = (Code.ECS.Gameplay.Features.Shoots.Systems.Recoil.RecoilRecoverySpeed)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Shoots.Systems.Recoil.RecoilRecoverySpeed));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveRecoilRecoverySpeed() {
        RemoveComponent(GameComponentsLookup.RecoilRecoverySpeed);
        return this;
    }
}
