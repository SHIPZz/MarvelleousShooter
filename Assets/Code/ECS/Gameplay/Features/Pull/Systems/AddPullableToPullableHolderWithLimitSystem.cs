using Entitas;

namespace Code.ECS.Gameplay.Features.Pull.Systems
{
    public class AddPullableToPullableHolderWithLimitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullables;
        private readonly IGroup<GameEntity> _pullableHolders;

        public AddPullableToPullableHolderWithLimitSystem(GameContext game)
        {
            _pullables = game.GetGroup(GameMatcher.AllOf(GameMatcher.Pullable, GameMatcher.Id));
            
            _pullableHolders = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.PullTargetList,
                    GameMatcher.MaxPullTargetHold,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity pullableHolder in _pullableHolders)
            foreach (GameEntity pullable in _pullables)
            {
                if (!IsHolderMatches(pullable, pullableHolder)) 
                    continue;
                
                if (!CanAddPullableToHolder(pullableHolder, pullable))
                    continue;

                pullableHolder.PullTargetList.Add(pullable.Id);
            }
        }

        private static bool IsHolderMatches(GameEntity pullable, GameEntity pullableHolder)
        {
            if (!pullable.hasPullProducerId || pullable.PullProducerId != pullableHolder.Id)
                return false;
            
            return true;
        }

        private bool CanAddPullableToHolder(GameEntity pullableHolder, GameEntity pullable)
        {
            return pullable.Id != pullableHolder.Id 
                   && pullableHolder.PullTargetList.Count < pullableHolder.MaxPullTargetHold 
                   && !pullableHolder.PullTargetList.Contains(pullable.Id); 
        }

    }
}