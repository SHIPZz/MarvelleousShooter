//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAmmoCount;

    public static Entitas.IMatcher<GameEntity> AmmoCount {
        get {
            if (_matcherAmmoCount == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AmmoCount);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAmmoCount = matcher;
            }

            return _matcherAmmoCount;
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

    public Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCount ammoCount { get { return (Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCount)GetComponent(GameComponentsLookup.AmmoCount); } }
    public float AmmoCount { get { return ammoCount.Value; } }
    public bool hasAmmoCount { get { return HasComponent(GameComponentsLookup.AmmoCount); } }

    public GameEntity AddAmmoCount(float newValue) {
        var index = GameComponentsLookup.AmmoCount;
        var component = (Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCount)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCount));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAmmoCount(float newValue) {
        var index = GameComponentsLookup.AmmoCount;
        var component = (Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCount)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCount));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAmmoCount() {
        RemoveComponent(GameComponentsLookup.AmmoCount);
        return this;
    }
}
