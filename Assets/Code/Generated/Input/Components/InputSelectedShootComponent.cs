//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherSelectedShoot;

    public static Entitas.IMatcher<InputEntity> SelectedShoot {
        get {
            if (_matcherSelectedShoot == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.SelectedShoot);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherSelectedShoot = matcher;
            }

            return _matcherSelectedShoot;
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

    public Code.ECS.Gameplay.Features.Input.SelectedShoot selectedShoot { get { return (Code.ECS.Gameplay.Features.Input.SelectedShoot)GetComponent(InputComponentsLookup.SelectedShoot); } }
    public Code.ECS.Gameplay.Features.Shoots.Enums.GunInputTypeId SelectedShoot { get { return selectedShoot.Value; } }
    public bool hasSelectedShoot { get { return HasComponent(InputComponentsLookup.SelectedShoot); } }

    public InputEntity AddSelectedShoot(Code.ECS.Gameplay.Features.Shoots.Enums.GunInputTypeId newValue) {
        var index = InputComponentsLookup.SelectedShoot;
        var component = (Code.ECS.Gameplay.Features.Input.SelectedShoot)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Input.SelectedShoot));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public InputEntity ReplaceSelectedShoot(Code.ECS.Gameplay.Features.Shoots.Enums.GunInputTypeId newValue) {
        var index = InputComponentsLookup.SelectedShoot;
        var component = (Code.ECS.Gameplay.Features.Input.SelectedShoot)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Input.SelectedShoot));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public InputEntity RemoveSelectedShoot() {
        RemoveComponent(InputComponentsLookup.SelectedShoot);
        return this;
    }
}
