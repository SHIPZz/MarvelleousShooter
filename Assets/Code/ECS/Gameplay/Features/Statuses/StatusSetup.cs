using System;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Statuses
{
    [Serializable]
    public class StatusSetup
    {
        public StatusTypeId StatusTypeId;
        public float Value;
        public float Duration;
        public float Period;
        public ReplaceSkinSetup TargetSkinSetup;
        public bool Stackable;

        public static StatusSetup Create(StatusTypeId id, float duration, float value)
        {
            var setup = new StatusSetup
            {
                StatusTypeId = id,
                Duration = duration,
                Value = value
            };
            
            return setup;
        }
    }

    [Serializable]
    public class ReplaceSkinSetup
    {
        public Sprite TargetSkin;
        public RuntimeAnimatorController AnimatorController;
    }
}