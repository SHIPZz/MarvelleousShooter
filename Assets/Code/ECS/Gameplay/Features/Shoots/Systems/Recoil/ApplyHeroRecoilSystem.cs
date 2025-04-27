using Code.Gameplay.Cameras;
using Entitas;
using UnityEngine;

public class ApplyHeroRecoilSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _heroGuns;
    private readonly ICameraProvider _cameraProvider;

    public ApplyHeroRecoilSystem(GameContext game, ICameraProvider cameraProvider)
    {
        _cameraProvider = cameraProvider;

        _heroGuns = game.GetGroup(GameMatcher
            .AllOf(GameMatcher.Shootable,
                GameMatcher.HorizontalRecoil,
                GameMatcher.Active,
                GameMatcher.CurrentRecoil,
                GameMatcher.ConnectedWithHero,
                GameMatcher.VerticalRecoil
            ));
    }

    public void Execute()
    {
        foreach (GameEntity heroGun in _heroGuns)
        {
            Transform cameraTransform = _cameraProvider.Camera.transform;
            Vector3 targetRecoilRotation = cameraTransform.eulerAngles;

            targetRecoilRotation.x += heroGun.CurrentRecoil.x;
            targetRecoilRotation.y += heroGun.CurrentRecoil.y;
            targetRecoilRotation.z = 0f;

            cameraTransform.rotation = Quaternion.Euler(targetRecoilRotation);
        }
    }
}