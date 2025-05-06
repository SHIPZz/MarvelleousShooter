using Code.ECS.View;
using KinematicCharacterController;
using UnityEngine;

public class EntityCharacterController : MonoBehaviour, ICharacterController
{
    [SerializeField] private EntityBehaviour _entityView;
    [SerializeField] private KinematicCharacterMotor _motor;

    private GameEntity Entity => _entityView.Entity;

    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
       
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        currentVelocity = Entity.FinalVelocity;

        if (Entity.JumpVelocity.y > 0)
        {
            _motor.ForceUnground(0);
            Entity.isOnGround = false;
        }

        Entity.ReplaceWorldPosition(transform.position);
    }

    public void BeforeCharacterUpdate(float deltaTime)
    {
        if (Entity.JumpVelocity.y > 0)
            _motor.ForceUnground(0);

        Entity.isOnGround = false;
    }

    public void PostGroundingUpdate(float deltaTime)
    {
    }

    public void AfterCharacterUpdate(float deltaTime) { }

    public bool IsColliderValidForCollisions(Collider coll)
    {
        return true;
    }

    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint,
        ref HitStabilityReport hitStabilityReport)
    {
        Entity.isOnGround = true;
    }

    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint,
        ref HitStabilityReport hitStabilityReport)
    {
        //d
    }

    public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint,
        Vector3 atCharacterPosition,
        Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
        //d
    }

    public void OnDiscreteCollisionDetected(Collider hitCollider)
    {
        //d
    }
}