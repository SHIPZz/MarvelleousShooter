using CodeBase.Gameplay.Enemies;
using CodeBase.Gameplay.Heroes;

namespace CodeBase.Gameplay.TargetSelectors
{
    public interface ITargetSelector
    {
        Hero SelectTarget(EnemyTypeId enemyTypeId);
    }
}