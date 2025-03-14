using BehaviorDesigner.Runtime.Tasks;

namespace Code.Gameplay.Enemies.AI
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