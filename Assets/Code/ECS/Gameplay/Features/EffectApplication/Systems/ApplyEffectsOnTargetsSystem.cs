using Code.ECS.Gameplay.Features.Effects;
using Code.ECS.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.ECS.Gameplay.Features.EffectApplication.Systems
{
    public class ApplyEffectsOnTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IEffectFactory _effectFactory;

        public ApplyEffectsOnTargetsSystem(GameContext game, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;

            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.TargetsBuffer,
                    GameMatcher.EffectSetups
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (int targetId in entity.TargetsBuffer)
            foreach (EffectSetup effectSetup in entity.EffectSetups)
            {
                _effectFactory.CreateEffect(effectSetup, targetId, ProducerId(entity));
            }
        }

        private int ProducerId(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}