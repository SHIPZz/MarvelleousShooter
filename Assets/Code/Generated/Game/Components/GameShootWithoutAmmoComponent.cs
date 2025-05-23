//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherShootWithoutAmmo;

    public static Entitas.IMatcher<GameEntity> ShootWithoutAmmo {
        get {
            if (_matcherShootWithoutAmmo == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ShootWithoutAmmo);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherShootWithoutAmmo = matcher;
            }

            return _matcherShootWithoutAmmo;
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

    static readonly Code.ECS.Gameplay.Features.Shoots.ShootWithoutAmmo shootWithoutAmmoComponent = new Code.ECS.Gameplay.Features.Shoots.ShootWithoutAmmo();

    public bool isShootWithoutAmmo {
        get { return HasComponent(GameComponentsLookup.ShootWithoutAmmo); }
        set {
            if (value != isShootWithoutAmmo) {
                var index = GameComponentsLookup.ShootWithoutAmmo;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : shootWithoutAmmoComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
