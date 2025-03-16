using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Enchants.Systems
{
    public class RemoveUnappliedEnchantsFromHolderSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _holders;
        
        public RemoveUnappliedEnchantsFromHolderSystem(IContext<GameEntity> game) : base(game)
        {
            _holders = game.GetGroup(GameMatcher.AllOf(GameMatcher.EnchantHolder));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher
                .AllOf(
                    GameMatcher.EnchantTypeId, 
                GameMatcher.Unapplied).Added());

        protected override bool Filter(GameEntity entity) => entity.hasEnchantTypeId;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            foreach (GameEntity holder in _holders)
            {
                holder.EnchantHolder.RemoveEnchant(entity.EnchantTypeId);
            }
        }
    }
}