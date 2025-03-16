using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Cooldown;
using Entitas;

namespace Code.ECS.Gameplay.Features.Pull.Systems
{
    public class SequentialMoveToPullableHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullableHolders;
        private readonly GameContext _game;
        private readonly List<GameEntity> _buffer = new(32);

        public SequentialMoveToPullableHolderSystem(GameContext game)
        {
            _game = game;
            _pullableHolders = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.PullTargetList,
                GameMatcher.PullTargetHolder,
                GameMatcher.CooldownUp,
                GameMatcher.PullTargetConsistently,
                GameMatcher.MinCountToPullTargets
            ));
        }

        public void Execute()
        {
            if (_pullableHolders.count <= 0)
                return;

            foreach (GameEntity pullTargetsHolder in _pullableHolders.GetEntities(_buffer))
            foreach (int targetId in pullTargetsHolder.PullTargetList)
            {
                if (pullTargetsHolder.PullTargetList.Count < pullTargetsHolder.MinCountToPullTargets)
                    continue;

                GameEntity target = _game.GetEntityWithId(targetId);

                if (!SetUpPullingAvailable(target, pullTargetsHolder))
                    continue;

                SetUpPulling(target);

                target.AddFollowTargetId(pullTargetsHolder.Id);
                pullTargetsHolder.PutOnCooldown();
                
                break;
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