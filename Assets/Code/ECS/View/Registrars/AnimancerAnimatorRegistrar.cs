using Code.ECS.Gameplay.Features.Animations;
using Code.ECS.Gameplay.Features.Animations.Enums;
using UnityEngine;

namespace Code.ECS.View.Registrars
{
    public class AnimancerAnimatorRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private AnimancerAnimatorPlayer _animancerAnimatorPlayer;
        
        public override void RegisterComponents()
        {
            if(_animancerAnimatorPlayer == null)
                _animancerAnimatorPlayer = GetComponent<AnimancerAnimatorPlayer>();
            
            Entity.AddAnimancerAnimator(_animancerAnimatorPlayer);
            
            if(!Entity.isReloadable)
                return;

            var reloadAnimDuration = _animancerAnimatorPlayer.GetState(AnimationTypeId.Recharge).Duration;
            
            Entity.AddReloadTime(reloadAnimDuration);
            Entity.AddReloadTimeLeft(reloadAnimDuration);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasAnimancerAnimator)
                Entity.RemoveAnimancerAnimator();
        }
    }
}