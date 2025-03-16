using Entitas;

namespace Code.ECS.Gameplay.Features.Effects.Systems
{
    public class ProcessDamageEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;

        public ProcessDamageEffectSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetId,
                    GameMatcher.EffectValue,
                    GameMatcher.DamageEffect
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity effect in _effects)
            {
                GameEntity target = effect.Target();

                effect.isProcessed = true;
                
                if(target.isDead)
                    continue;

                target.ReplaceCurrentHp(target.CurrentHp - effect.EffectValue);
                
                // if(target.hasDamageTakenAnimator)
                //     target.DamageTakenAnimator.PlayDamageTaken();
            }
        }
    }
}