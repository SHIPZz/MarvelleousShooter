using System;
using System.Threading;
using CodeBase.Extensions;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Gameplay.Shootables.States
{
    public class SwitchGunState : BaseShootState, IPayloadState<Shoot>
    {
        private CancellationTokenSource _cancellationToken = new();
        private Shoot _previousGun;
        private Shoot _targetGun;

        public SwitchGunState(IInputService inputService,
            IShootService shootService, IShootStateMachine shootStateMachine, IHeroService heroService,
            ITransitionFactory transitionFactory)
            : base(inputService, shootService, shootStateMachine, heroService, transitionFactory)
        {
            AddTransition<AimIdleTransition>();
            AddTransition<IdleFocusTransition>();
            AddTransition<IdleTransition>();
            AddTransition<MovementTransition>();
            AddTransition<ShootTransition>();
        }

        public async void Enter(Shoot targetGun)
        {
            TransitionAvailable = false;
            
            try
            {
                _targetGun = targetGun;

                ResetToken();

                _previousGun = _shootService.CurrentShoot;
                
                _targetGun.MarkShootingAvailable(false);
                _previousGun.MarkShootingAvailable(false);

                _previousGun.StopShooting();
                _targetGun.StopShooting();

                _shootService.SetCurrentShoot(targetGun);

                await _previousGun.ShootAnimator.StartHiding().AttachExternalCancellation(_cancellationToken.Token);

                Debug.Log($"hide");

                targetGun.gameObject.SetActive(true);

                _previousGun.gameObject.SetActive(false);

                await targetGun.ShootAnimator.StartGetting().AttachExternalCancellation(_cancellationToken.Token);


                Debug.Log($"get");
            }
            catch (OperationCanceledException e)
            {
                TransitionAvailable = true;
            }
            catch (Exception e) { }
            finally
            {
                TransitionAvailable = true;
            }
        }

        public void Exit()
        {
            _cancellationToken.Cleanup();
            _previousGun.ShootAnimator.Animancer.Stop();
            _shootService.MarkShootingAvailable(true);
        }

        private void ResetToken()
        {
            _cancellationToken.Cleanup();
            _cancellationToken = new();
        }
    }
}