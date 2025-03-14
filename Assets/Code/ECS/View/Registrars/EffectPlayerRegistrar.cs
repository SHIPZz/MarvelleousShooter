using Code.Gameplay.Shootables.Visuals;
using UnityEngine;

namespace Code.ECS.View.Registrars
{
    public class EffectPlayerRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private EffectPlayer _effectPlayer;
        
        public override void RegisterComponents()
        {
            Entity.AddEffectPlayer(_effectPlayer);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasEffectPlayer)
                Entity.RemoveEffectPlayer();
        }
    }
}