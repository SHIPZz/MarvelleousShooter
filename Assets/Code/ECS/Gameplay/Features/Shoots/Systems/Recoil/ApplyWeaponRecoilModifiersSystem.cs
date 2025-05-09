using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public class ApplyWeaponRecoilModifiersSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _guns;
        private readonly IGroup<GameEntity> _heroes;

        public ApplyWeaponRecoilModifiersSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Active));

            _guns = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Gun,
                GameMatcher.Shooting,
                GameMatcher.ConnectedWithHero,
                GameMatcher.AimMultiplier,
                GameMatcher.AimJumpMultiplier,
                GameMatcher.JumpMultiplier,
                GameMatcher.HorizontalRecoil,
                GameMatcher.VerticalRecoil,
                GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity shoot in _guns)
            {
                var targetHorizontalRecoil = shoot.HorizontalRecoil;
                var targetVerticalRecoil = shoot.VerticalRecoil;

                if (shoot.isAiming && !hero.isOnGround)
                {
                    targetHorizontalRecoil *= shoot.AimJumpMultiplier;
                    targetVerticalRecoil *= shoot.AimJumpMultiplier;
                }
                else if (shoot.isAiming)
                {
                    targetHorizontalRecoil *= shoot.AimMultiplier;
                    targetVerticalRecoil *= shoot.AimMultiplier;
                }
                else if (!hero.isOnGround)
                {
                    targetHorizontalRecoil *= shoot.JumpMultiplier;
                    targetVerticalRecoil *= shoot.JumpMultiplier;
                }

                
                shoot.ReplaceHorizontalRecoil(targetHorizontalRecoil);
                shoot.ReplaceVerticalRecoil(targetVerticalRecoil);
            }
        }
    }
}