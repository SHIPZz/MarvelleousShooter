using BehaviorDesigner.Runtime.Tasks;

namespace CodeBase.Gameplay.Enemies.AI
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