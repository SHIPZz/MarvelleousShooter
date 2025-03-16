using Entitas;

namespace Code.ECS.Gameplay.Features.Pull.Systems
{
    public class MoveToPullableHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullableHolders;
        private readonly GameContext _game;

        public MoveToPullableHolderSystem(GameContext game)
        {
            _game = game;
            _pullableHolders = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.PullTargetList,
                GameMatcher.PullTargetHolder,
                GameMatcher.MinCountToPullTargets
                ).NoneOf(GameMatcher.PullTargetConsistently));
        }

        public void Execute()
        {
            if (_pullableHolders.count <= 0)
                return;

            foreach (GameEntity pullTargetsHolder in _pullableHolders)
            foreach (int targetId in pullTargetsHolder.PullTargetList)
            {
                if (pullTargetsHolder.PullTargetList.Count < pullTargetsHolder.MinCountToPullTargets)
                    continue;

                GameEntity target = _game.GetEntityWithId(targetId);

                if (!SetUpPullingAvailable(target, pullTargetsHolder))
                    continue;

                SetUpPulling(target);

                target.AddFollowTargetId(pullTargetsHolder.Id);
            }
        }
        
        private static bool SetUpPullingAvailable(GameEntity target, GameEntity pullTargetsHolder)
        {
            if (target == null || target.isPulling)
                return false;

            if (pullTargetsHolder.Id != target.PullProducerId)
                return false;

            return true;
        }

        private static void SetUpPulling(GameEntity target)
        {
            target.isPulling = true;
            target.isMoving = true;
            target.isMovingAvailable = true;
        }
    }
}