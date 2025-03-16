using System;
using Code.ECS.Common.Entity;
using Code.ECS.Common.Services;
using Code.ECS.Extensions;

namespace Code.ECS.Gameplay.Features.Effects.Factory
{
    public class EffectFactory : IEffectFactory
    {
        private readonly IIdentifierService _identifierService;

        public EffectFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEffect(EffectSetup effectSetup, int targetId, int producerId)
        {
            switch (effectSetup.EffectTypeId)
            {
                case EffectTypeId.None:
                    break;

                case EffectTypeId.Damage:
                    return CreateDamage(targetId, producerId, effectSetup.Value);
                
                case EffectTypeId.Heal:
                    return CreateHeal(targetId, producerId, effectSetup.Value);
            }

            throw new ArgumentOutOfRangeException(nameof(effectSetup.EffectTypeId), effectSetup.EffectTypeId, null);
        }

        private GameEntity CreateHeal(int targetId, int producerId, float value)
        {
            return  CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddTargetId(targetId)
                    .AddEffectValue(value)
                    .AddEffectTypeId(EffectTypeId.Heal)
                    .AddProducerId(producerId)
                    .With(x => x.isHealEffect = true)
                    .With(x => x.isEffect = true)
                ;
        }
        
        private GameEntity CreateDamage(int targetId, int producerId, float value)
        {
          return  CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddEffectValue(value)
                .AddEffectTypeId(EffectTypeId.Damage)
                .AddProducerId(producerId)
                .With(x => x.isDamageEffect = true)
                .With(x => x.isEffect = true)
                ;
        }
    }
}