using System;
using Code.ECS.Common.Entity;
using Code.ECS.Common.Services;
using Code.ECS.Extensions;
using Code.ECS.Gameplay.Features.Enchants;

namespace Code.ECS.Gameplay.Features.Statuses
{
    public class StatusFactory : IStatusFactory
    {
        private readonly IIdentifierService _identifierService;

        public StatusFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateStatus(StatusSetup statusSetup, int targetId, int producerId)
        {
            GameEntity status = null;

            switch (statusSetup.StatusTypeId)
            {
                case StatusTypeId.None:
                    break;
                
                case StatusTypeId.Freeze:
                    status = CreateFreezeStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;

                case StatusTypeId.Poison:
                    status = CreatePoisonStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                case StatusTypeId.SpeedUp:
                    status = CreateSpeedUpStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                case StatusTypeId.MaxHpIncrease:
                    status = CreateMaxHpStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                case StatusTypeId.Scale:
                    status = CreateScaleIncreaseStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;

                case StatusTypeId.Invulnerable:
                    status = CreateInvulnerableStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                case StatusTypeId.PoisonEnchant:
                    status = CreatePoisonEnchantStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                case StatusTypeId.ExplosiveEnchant:
                    status = CreateExplosiveEnchantStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                case StatusTypeId.Hex:
                    status = CreateHexEnchantStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                case StatusTypeId.Vampirism:
                    status = CreateVampirismStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                case StatusTypeId.PeriodicDamage:
                    status = CreatePeriodicDamageStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                default:
                    throw new ArgumentException("no status");
            }

            return status
                    .With(x => x.AddDuration(statusSetup.Duration), when: statusSetup.Duration > 0)
                    .With(x => x.AddTimeLeft(statusSetup.Duration), when: statusSetup.Duration > 0)
                    .With(x => x.AddPeriod(statusSetup.Period), when: statusSetup.Period > 0)
                    .With(x => x.AddTimeSinceLastTick(0), when: statusSetup.Period > 0)
                ;
        }
        
        private GameEntity CreatePeriodicDamageStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddEffectValue(value)
                .AddStatusTypeId(statusSetup.StatusTypeId)
                .AddProducerId(producerId)
                .With(x => x.isStatus = true)
                .With(x => x.isPeriodicDamageStatus = true);
        }

        
        private GameEntity CreateVampirismStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddEffectValue(value)
                .AddStatusTypeId(statusSetup.StatusTypeId)
                .AddProducerId(producerId)
                .With(x => x.isStatus = true)
                .With(x => x.isVampirism = true);
        }

        
        private GameEntity CreateHexEnchantStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddEffectValue(value)
                .AddEnchantTypeId(EnchantTypeId.Hex)
                .AddStatusTypeId(statusSetup.StatusTypeId)
                .AddProducerId(producerId)
                .With(x => x.isStatus = true)
                .With(x => x.isHexEnchant = true);
        }
        
        private GameEntity CreateExplosiveEnchantStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddEffectValue(value)
                .AddEnchantTypeId(EnchantTypeId.ExplosiveEnchant)
                .AddStatusTypeId(statusSetup.StatusTypeId)
                .AddProducerId(producerId)
                .With(x => x.isStatus = true)
                .With(x => x.isExplosiveEnchant = true);
        }
        
        private GameEntity CreatePoisonEnchantStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddEffectValue(value)
                .AddEnchantTypeId(EnchantTypeId.PoisonArmaments)
                .AddStatusTypeId(statusSetup.StatusTypeId)
                .AddTargetId(targetId)
                .AddProducerId(producerId)
                .With(x => x.isStatus = true)
                .With(x => x.isPoisonEnchant = true);
        }
        
        private GameEntity CreateInvulnerableStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddEffectValue(value)
                .AddStatusTypeId(statusSetup.StatusTypeId)
                .AddProducerId(producerId)
                .With(x => x.isStatus = true)
                .With(x => x.isInvulnerableStatus = true);
        }

        private GameEntity CreateScaleIncreaseStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddEffectValue(value)
                .AddStatusTypeId(statusSetup.StatusTypeId)
                .AddProducerId(producerId)
                .With(x => x.isStatus = true)
                .With(x => x.isScaleIncrease = true);
        }

        private GameEntity CreateMaxHpStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return  CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddTargetId(targetId)
                    .AddEffectValue(value)
                    .AddStatusTypeId(statusSetup.StatusTypeId)
                    .AddProducerId(producerId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isMaxHpIncrease = true)
                ;
        }
        
        private GameEntity CreatePoisonStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return  CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddTargetId(targetId)
                    .AddEffectValue(value)
                    .AddStatusTypeId(statusSetup.StatusTypeId)
                    .AddProducerId(producerId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isPoison = true)
                ;
        }
        
        private GameEntity CreateSpeedUpStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return  CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddTargetId(targetId)
                    .AddEffectValue(value)
                    .AddStatusTypeId(statusSetup.StatusTypeId)
                    .AddProducerId(producerId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isSpeedUp = true)
                ;
        }
        
        private GameEntity CreateFreezeStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return  CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddTargetId(targetId)
                    .AddEffectValue(value)
                    .AddStatusTypeId(statusSetup.StatusTypeId)
                    .AddProducerId(producerId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isFreeze = true)
                ;
        }
    }
}