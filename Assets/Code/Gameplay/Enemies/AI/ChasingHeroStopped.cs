using BehaviorDesigner.Runtime.Tasks;

namespace Code.Gameplay.Enemies.AI
{
    public class ChasingHero : EnemyConditional
    {
        public override TaskStatus OnUpdate()
        {
            return Movable.RemainingDistance <= Movable.StopDistance
                ? TaskStatus.Failure
                : TaskStatus.Running;
        }
    }
}