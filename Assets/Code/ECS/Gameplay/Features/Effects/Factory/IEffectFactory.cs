namespace Code.ECS.Gameplay.Features.Effects.Factory
{
    public interface IEffectFactory
    {
        GameEntity CreateEffect(EffectSetup effectSetup, int targetId, int producerId);
    }
}