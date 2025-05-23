//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCameraRotationSharpness;

    public static Entitas.IMatcher<GameEntity> CameraRotationSharpness {
        get {
            if (_matcherCameraRotationSharpness == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CameraRotationSharpness);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCameraRotationSharpness = matcher;
            }

            return _matcherCameraRotationSharpness;
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

    public Code.ECS.Gameplay.Features.Cameras.CameraRotationSharpnessComponent cameraRotationSharpness { get { return (Code.ECS.Gameplay.Features.Cameras.CameraRotationSharpnessComponent)GetComponent(GameComponentsLookup.CameraRotationSharpness); } }
    public float CameraRotationSharpness { get { return cameraRotationSharpness.Value; } }
    public bool hasCameraRotationSharpness { get { return HasComponent(GameComponentsLookup.CameraRotationSharpness); } }

    public GameEntity AddCameraRotationSharpness(float newValue) {
        var index = GameComponentsLookup.CameraRotationSharpness;
        var component = (Code.ECS.Gameplay.Features.Cameras.CameraRotationSharpnessComponent)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Cameras.CameraRotationSharpnessComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCameraRotationSharpness(float newValue) {
        var index = GameComponentsLookup.CameraRotationSharpness;
        var component = (Code.ECS.Gameplay.Features.Cameras.CameraRotationSharpnessComponent)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Cameras.CameraRotationSharpnessComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCameraRotationSharpness() {
        RemoveComponent(GameComponentsLookup.CameraRotationSharpness);
        return this;
    }
}
