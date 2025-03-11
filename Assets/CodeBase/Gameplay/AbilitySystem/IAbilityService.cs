namespace CodeBase.Gameplay.AbilitySystem
{
    public interface IAbilityService
    {
        void Init();
        void Start<T>(AbilityOwnerTypeId abilityOwnerTypeId = AbilityOwnerTypeId.Player) where T : AbstractAbility;
        void Stop(AbilityTypeId abilityTypeId,  AbilityOwnerTypeId abilityOwnerTypeId = AbilityOwnerTypeId.Player);
        void AddAbilityOwner(AbilityOwner abilityOwner);
    }
}