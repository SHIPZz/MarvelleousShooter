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
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasAnimancerAnimator)
                Entity.RemoveAnimancerAnimator();
        }
    }
}