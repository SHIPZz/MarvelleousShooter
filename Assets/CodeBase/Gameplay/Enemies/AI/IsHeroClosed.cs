using BehaviorDesigner.Runtime.Tasks;
using CodeBase.Gameplay.Movement;
using CodeBase.Extensions;

namespace CodeBase.Gameplay.Enemies.AI
{
    public class IsHeroClosed : EnemyConditional
    {
        public override TaskStatus OnUpdate()
        {
            return Movable.RemainingDistance <= Movable.StopDistance 
                ? TaskStatus.Success
                : TaskStatus.Failure;
        }
    }
}