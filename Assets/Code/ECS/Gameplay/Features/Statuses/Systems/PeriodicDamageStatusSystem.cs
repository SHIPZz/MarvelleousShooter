using Code.ECS.Common.Time;
using Code.ECS.Gameplay.Features.Effects;
using Code.ECS.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.ECS.Gameplay.Features.Statuses.Systems
{
    public class PeriodicDamageStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly ITimeService _timeService;
        private readonly IEffectFactory _effectFactory;

        public PeriodicDamageStatusSystem(GameContext game, ITimeService timeService, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            _timeService = timeService;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Period,
                    GameMatcher.TimeSinceLastTick,
                    GameMatcher.EffectValue,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId
                ));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses)
            {
                if (status.TimeSinceLastTick >= 0)
                {
                    status.ReplaceTimeSinceLastTick(status.TimeSinceLastTick - _timeService.DeltaTime);
                }
                else
                {
                    status.ReplaceTimeSinceLastTick(status.Period);

                    _effectFactory.CreateEffect(EffectSetup.Create(EffectTypeId.Damage, status.EffectValue),
                        status.TargetId, status.ProducerId);
                }
            }
        }
    }
}