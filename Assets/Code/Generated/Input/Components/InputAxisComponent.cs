//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherAxis;

    public static Entitas.IMatcher<InputEntity> Axis {
        get {
            if (_matcherAxis == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Axis);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherAxis = matcher;
            }

            return _matcherAxis;
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
public partial class InputEntity {

    public Code.ECS.Gameplay.Features.Input.Axis axis { get { return (Code.ECS.Gameplay.Features.Input.Axis)GetComponent(InputComponentsLookup.Axis); } }
    public UnityEngine.Vector3 Axis { get { return axis.Value; } }
    public bool hasAxis { get { return HasComponent(InputComponentsLookup.Axis); } }

    public InputEntity AddAxis(UnityEngine.Vector3 newValue) {
        var index = InputComponentsLookup.Axis;
        var component = (Code.ECS.Gameplay.Features.Input.Axis)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Input.Axis));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public InputEntity ReplaceAxis(UnityEngine.Vector3 newValue) {
        var index = InputComponentsLookup.Axis;
        var component = (Code.ECS.Gameplay.Features.Input.Axis)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Input.Axis));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public InputEntity RemoveAxis() {
        RemoveComponent(InputComponentsLookup.Axis);
        return this;
    }
}
