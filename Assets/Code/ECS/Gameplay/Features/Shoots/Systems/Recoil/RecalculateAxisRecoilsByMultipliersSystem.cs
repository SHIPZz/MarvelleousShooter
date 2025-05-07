using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    public class RecalculateAxisRecoilsByMultipliersSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _shoots;
        private readonly IGroup<GameEntity> _heroes;

        public RecalculateAxisRecoilsByMultipliersSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Active));

            _shoots = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Shootable,
                GameMatcher.ConnectedWithHero,
                GameMatcher.AimMultiplier,
                GameMatcher.AimJumpMultiplier,
                GameMatcher.JumpMultiplier,
                GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity shoot in _shoots)
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