using Code.ECS.Common.Time;
using Entitas;
using UnityEngine;

public class CalculateRecoilSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _shoots;
    private readonly ITimeService _timeService;

    public CalculateRecoilSystem(GameContext game, ITimeService timeService)
    {
        _timeService = timeService;
        _shoots = game.GetGroup(GameMatcher.AllOf(GameMatcher.Shootable, GameMatcher.Active));
    }

    public void Execute()
    {
        foreach (GameEntity shoot in _shoots)
        {
            if (shoot.isShooting)
            {
                shoot.ReplaceTargetRecoil(shoot.TargetRecoil + new Vector3(shoot.VerticalRecoil, shoot.HorizontalRecoil));

                Vector3 targetRecoil = Vector3.Lerp(shoot.CurrentRecoil, shoot.TargetRecoil, _timeService.DeltaTime * shoot.RecoilSpeed);
                shoot.ReplaceCurrentRecoil(targetRecoil);
            }
            else
            {
                Vector3 currentRecoil = Vector3.Lerp(shoot.CurrentRecoil, Vector3.zero, _timeService.DeltaTime * shoot.RecoilRecoverySpeed);
                shoot.ReplaceCurrentRecoil(currentRecoil);

                shoot.ReplaceTargetRecoil(currentRecoil);
            }
        }
    }
}