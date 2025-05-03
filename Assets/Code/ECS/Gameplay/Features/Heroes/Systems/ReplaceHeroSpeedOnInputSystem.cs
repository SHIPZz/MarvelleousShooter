using Code.ECS.Gameplay.Features.CharacterStats;
using Code.ECS.Gameplay.Features.Movement.Configs;
using Code.Gameplay.Heroes.Configs;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class ReplaceHeroSpeedOnInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<InputEntity> _inputs;
        private readonly HeroConfig _heroConfig;

        public ReplaceHeroSpeedOnInputSystem(GameContext game, InputContext input, HeroConfig heroConfig)
        {
            _heroConfig = heroConfig;
            _inputs = input.GetGroup(InputMatcher.Input);

            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.MovingAvailable,
                    GameMatcher.Active,
                    GameMatcher.OnGround));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            foreach (GameEntity hero in _heroes)
            {
                if (!input.isMovementRequested)
                {
                    hero.BaseStats[Stats.Speed] = 0;
                    return;
                }

                MovementData movementData = _heroConfig.MovementData;

                Debug.Log($"{input.isRunningPressed}");

                hero.BaseStats[Stats.Speed] = input.isRunningPressed ? movementData.RunningSpeed : movementData.Speed;
            }
        }
    }
}