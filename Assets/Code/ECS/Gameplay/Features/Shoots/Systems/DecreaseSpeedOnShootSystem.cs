using Code.ECS.Gameplay.Features.CharacterStats;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class DecreaseSpeedOnShootSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;
        private readonly IGroup<GameEntity> _gunHolders;

        public DecreaseSpeedOnShootSystem(GameContext game)
        {
            _guns = game.GetGroup(GameMatcher.AllOf(GameMatcher.Shootable, 
                GameMatcher.Id));
            
            _gunHolders = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Speed, 
                    GameMatcher.InitialSpeed,
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers,
                    GameMatcher.Active,
                    GameMatcher.CurrentGunId));
        }

        public void Execute()
        {
            foreach (GameEntity gunHolder in _gunHolders)
            foreach (GameEntity gun in _guns)
            {
                if(gunHolder.CurrentGunId != gun.Id)
                    continue;

                if (gun.isShootingContinuously)
                {
                    gunHolder.StatModifiers[Stats.Speed] = -(gunHolder.InitialSpeed / 2);
                }
                else
                {
                    gunHolder.StatModifiers[Stats.Speed] = 0;
                }
            }
        }
    }
}