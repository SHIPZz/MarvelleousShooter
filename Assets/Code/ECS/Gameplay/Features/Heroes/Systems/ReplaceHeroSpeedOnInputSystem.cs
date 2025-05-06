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
                    GameMatcher.OnGround,
                    GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            foreach (GameEntity hero in _heroes)
            {
                MovementData movementData = _heroConfig.MovementData;

                hero.BaseStats[Stats.Speed] = input.isRunningPressed && hero.isRunningAvailable ? movementData.RunningSpeed : movementData.Speed;
            }
        }
        

    }
}