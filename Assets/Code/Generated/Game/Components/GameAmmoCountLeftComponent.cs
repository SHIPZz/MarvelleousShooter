//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAmmoCountLeft;

    public static Entitas.IMatcher<GameEntity> AmmoCountLeft {
        get {
            if (_matcherAmmoCountLeft == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AmmoCountLeft);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAmmoCountLeft = matcher;
            }

            return _matcherAmmoCountLeft;
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

    public Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCountLeft ammoCountLeft { get { return (Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCountLeft)GetComponent(GameComponentsLookup.AmmoCountLeft); } }
    public float AmmoCountLeft { get { return ammoCountLeft.Value; } }
    public bool hasAmmoCountLeft { get { return HasComponent(GameComponentsLookup.AmmoCountLeft); } }

    public GameEntity AddAmmoCountLeft(float newValue) {
        var index = GameComponentsLookup.AmmoCountLeft;
        var component = (Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCountLeft)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCountLeft));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAmmoCountLeft(float newValue) {
        var index = GameComponentsLookup.AmmoCountLeft;
        var component = (Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCountLeft)CreateComponent(index, typeof(Code.ECS.Gameplay.Features.Shoots.Systems.Ammo.AmmoCountLeft));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAmmoCountLeft() {
        RemoveComponent(GameComponentsLookup.AmmoCountLeft);
        return this;
    }
}
