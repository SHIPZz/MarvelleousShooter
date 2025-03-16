using Entitas;

namespace Code.ECS.Gameplay.Features.Enchants.Systems
{
    public class ApplyEnchantToHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enchantHolders;
        private readonly IGroup<GameEntity> _enchants;

        public ApplyEnchantToHolderSystem(GameContext game)
        {
            _enchantHolders = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.EnchantHolder));

            _enchants = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TimeLeft,
                    GameMatcher.EnchantTypeId
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity enchantHolder in _enchantHolders)
            foreach (GameEntity enchant in _enchants)
            {
                enchantHolder.EnchantHolder.AddEnchant(enchant.EnchantTypeId);
            }
        }
    }
}