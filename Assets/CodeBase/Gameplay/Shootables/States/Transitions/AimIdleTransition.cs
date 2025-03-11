namespace CodeBase.Gameplay.Shootables.States.Transitions
 {
     public class AimIdleTransition : BaseShootTransition,ITransition
     {
         public virtual bool ShouldTransition()
         {
             return  IsAimingWithoutShootInput() || IsAirAiming();
         }
 
         public virtual void MoveToTargetState()
         {
             ShootStateMachine.Enter<AimIdleState>();
         }
     }
 }