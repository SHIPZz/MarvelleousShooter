using KinematicCharacterController;
using UnityEngine;
using Zenject;

public class PerfectCharacterController : MonoBehaviour, ICharacterController
{
    [Inject] private GameContext _game;

    /// <summary>
    /// (Called by KinematicCharacterMotor during its update cycle)
    /// This is where you tell your character what its rotation should be right now. 
    /// This is the ONLY place where you should set the character's rotation
    /// </summary>
    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        GameEntity camera = _game.GetGroup(GameMatcher.MainCamera).GetSingleEntity();

        if (camera != null)
            currentRotation = camera.CurrentCameraRotation;
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        GameEntity hero = _game.GetGroup(GameMatcher.Hero).GetSingleEntity();

        currentVelocity = hero.FinalVelocity;
        //d
    }

    public void BeforeCharacterUpdate(float deltaTime)
    {
        //d
    }

    public void PostGroundingUpdate(float deltaTime)
    {
        //d
    }

    public void AfterCharacterUpdate(float deltaTime)
    {
        //d
    }

    public bool IsColliderValidForCollisions(Collider coll)
    {
        //d
        return true;
    }

    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint,
        ref HitStabilityReport hitStabilityReport)
    {
        //d
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