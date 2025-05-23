//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBaseCameraRotation;

    public static Entitas.IMatcher<GameEntity> BaseCameraRotation {
        get {
            if (_matcherBaseCameraRotation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BaseCameraRotation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBaseCameraRotation = matcher;
            }

            return _matcherBaseCameraRotation;
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

    public Code.ECS.Gameplay.Features.Cameras.BaseCameraRotation baseCameraRotation { get { return (Code.ECS.Gameplay.Features.Cameras.BaseCameraRotation)GetComponent(GameComponentsLookup.BaseCameraRotation); } }
    public UnityEngine.Quaternion BaseCameraRotation { get { return baseCameraRotation.Value; } }
    public bool hasBaseCameraRotation { get { return HasComponent(GameComponentsLookup.BaseCameraRotation); } }

    public GameEntity AddBaseCameraRotation(UnityEngine.Quaternion newValue) {
        var index = GameComponentsLookup.BaseCameraRotation;
        var component = (Code.ECS.Gameplay.Features.Cameras.BaseCameraRotation)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Cameras.BaseCameraRotation));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceBaseCameraRotation(UnityEngine.Quaternion newValue) {
        var index = GameComponentsLookup.BaseCameraRotation;
        var component = (Code.ECS.Gameplay.Features.Cameras.BaseCameraRotation)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Cameras.BaseCameraRotation));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveBaseCameraRotation() {
        RemoveComponent(GameComponentsLookup.BaseCameraRotation);
        return this;
    }
}
