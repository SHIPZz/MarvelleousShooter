using Code.Gameplay.Animations;
using UnityEngine;

namespace Code.ECS.View.Registrars
{
    public class AnimancerAnimatorRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private AnimancerAnimatorPlayer _animancerAnimatorPlayer;
        
        public override void RegisterComponents()
        {
            Entity.AddAnimancerAnimator(_animancerAnimatorPlayer);
            
            if(!Entity.isReloadable)
                return;

            var reloadAnimDuration = _animancerAnimatorPlayer.GetState(AnimationTypeId.Reload).Duration;
            
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