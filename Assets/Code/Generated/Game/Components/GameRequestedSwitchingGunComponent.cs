//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRequestedSwitchingGun;

    public static Entitas.IMatcher<GameEntity> RequestedSwitchingGun {
        get {
            if (_matcherRequestedSwitchingGun == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RequestedSwitchingGun);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRequestedSwitchingGun = matcher;
            }

            return _matcherRequestedSwitchingGun;
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

    public Code.ECS.Gameplay.Features.Shoots.Systems.Switching.RequestedSwitchingGun requestedSwitchingGun { get { return (Code.ECS.Gameplay.Features.Shoots.Systems.Switching.RequestedSwitchingGun)GetComponent(GameComponentsLookup.RequestedSwitchingGun); } }
    public Code.ECS.Gameplay.Features.Shoots.Enums.GunInputTypeId RequestedSwitchingGun { get { return requestedSwitchingGun.Value; } }
    public bool hasRequestedSwitchingGun { get { return HasComponent(GameComponentsLookup.RequestedSwitchingGun); } }

    public GameEntity AddRequestedSwitchingGun(Code.ECS.Gameplay.Features.Shoots.Enums.GunInputTypeId newValue) {
        var index = GameComponentsLookup.RequestedSwitchingGun;
        var component = (Code.ECS.Gameplay.Features.Shoots.Systems.Switching.RequestedSwitchingGun)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Shoots.Systems.Switching.RequestedSwitchingGun));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceRequestedSwitchingGun(Code.ECS.Gameplay.Features.Shoots.Enums.GunInputTypeId newValue) {
        var index = GameComponentsLookup.RequestedSwitchingGun;
        var component = (Code.ECS.Gameplay.Features.Shoots.Systems.Switching.RequestedSwitchingGun)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Shoots.Systems.Switching.RequestedSwitchingGun));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveRequestedSwitchingGun() {
        RemoveComponent(GameComponentsLookup.RequestedSwitchingGun);
        return this;
    }
}
