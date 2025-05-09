using System.Collections.Generic;
using Code.ECS.Common.Time;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Cooldowns
{
    public class CalculateShootCooldownSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;
        private readonly ITimeService _timeService;
        private readonly List<GameEntity> _buffer = new(16);

        public CalculateShootCooldownSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _guns = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ShootCooldown,
                    GameMatcher.Gun,
                    GameMatcher.ShootCooldownLeft
                ).NoneOf(GameMatcher.ShootCooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity gun in _guns.GetEntities(_buffer))
            {
                if (gun.ShootCooldownLeft > 0)
                {
                    gun.ReplaceShootCooldownLeft(gun.ShootCooldownLeft - _timeService.DeltaTime);
                    gun.isShootCooldownUp = gun.ShootCooldownLeft <= 0;
                }
                
                if(gun.isShootCooldownUp) 
                    gun.ReplaceShootCooldownLeft(0);
            }
        }
    }
}