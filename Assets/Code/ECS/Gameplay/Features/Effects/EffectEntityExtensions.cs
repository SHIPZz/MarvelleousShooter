﻿namespace Code.ECS.Gameplay.Features.Effects
{
    public static class EffectEntityExtensions
    {
        public static GameEntity Producer(this GameEntity effect)
        {
           return effect.hasProducerId 
               ? GameContext.GetEntityWithId(effect.ProducerId)
                : null;
        }
        
        public static GameEntity Target(this GameEntity effect)
        {
            return effect.hasTargetId 
                ? GameContext.GetEntityWithId(effect.TargetId)
                : null;
        }
        
        private static GameContext GameContext => Contexts.sharedInstance.game;
    }
}