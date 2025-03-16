using System.Collections.Generic;
using Code.ECS.Gameplay.Features.CharacterStats;
using Code.ECS.Gameplay.Features.CharacterStats.Indexing;
using Code.ECS.Gameplay.Features.Effects;
using Code.ECS.Gameplay.Features.Statuses;
using Code.ECS.Gameplay.Features.Statuses.Indexing;
using Entitas;
using Zenject;

namespace Code.ECS.Common.EntityIndicies
{
    public class GameEntityIndices : IInitializable
    {
        private readonly GameContext _game;

        public const string StatusesOfType = "StatusesOfType";
        public const string StatChanges = "StatChanges";

        public GameEntityIndices(GameContext game)
        {
            _game = game;
        }

        public void Initialize()
        {
            IGroup<GameEntity> group = _game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Status,
                GameMatcher.StatusTypeId,
                GameMatcher.TargetId,
                GameMatcher.Duration,
                GameMatcher.TimeLeft));

            _game.AddEntityIndex(new EntityIndex<GameEntity, StatusKey>(StatusesOfType,
                group,GetTargetStatusKey,
                new StatusKeyEqualityComparer()));
            
            IGroup<GameEntity> statGroup = _game.GetGroup(GameMatcher.AllOf(
                GameMatcher.StatChange,
                GameMatcher.TargetId
            ));
            
            _game.AddEntityIndex(new EntityIndex<GameEntity, StatKey>(StatChanges,
                statGroup,GetTargetStatKey,
                new StatKeyEqualityComparer()));
            
            
        }

        private StatKey GetTargetStatKey(GameEntity entity, IComponent component)
        {
            return new StatKey(
                (component as TargetId)?.Value ?? entity.TargetId,
                (component as StatChange)?.Value ?? entity.StatChange);
        }
        
        private StatusKey GetTargetStatusKey(GameEntity entity, IComponent component)
        {
            return new StatusKey(
                (component as TargetId)?.Value ?? entity.TargetId,
                (component as StatusTypeIdComponent)?.Value ?? entity.StatusTypeId);
        }
    }

    public static class ContextIndicesExtensions
    {
        public static HashSet<GameEntity> TargetStatusesOfType(this GameContext context,
            StatusTypeId statusTypeId,
            int targetId)
        {
            return ((EntityIndex<GameEntity, StatusKey>)context.GetEntityIndex(GameEntityIndices.StatusesOfType))
                .GetEntities(new StatusKey(targetId, statusTypeId))
                ;
        }
        
        public static HashSet<GameEntity> TargetStatChanges(this GameContext context,
            Stats stat,
            int targetId)
        {
            return ((EntityIndex<GameEntity, StatKey>)context.GetEntityIndex(GameEntityIndices.StatChanges))
                .GetEntities(new StatKey(targetId, stat))
                ;
        }
    }
}