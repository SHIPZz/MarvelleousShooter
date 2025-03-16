using System.Linq;
using Code.ECS.Common.EntityIndicies;
using Code.ECS.Extensions;

namespace Code.ECS.Gameplay.Features.Statuses.Applier
{
    public class StatusApplier : IStatusApplier
    {
        private readonly IStatusFactory _statusFactory;
        private readonly GameContext _game;

        public StatusApplier(IStatusFactory statusFactory, GameContext game)
        {
            _game = game;
            _statusFactory = statusFactory;
        }

        public GameEntity ApplyStatus(StatusSetup setup, int producerId, int targetId)
        {
            GameEntity status = _game.TargetStatusesOfType(setup.StatusTypeId, targetId).FirstOrDefault();

            return status != null
                ? status.ReplaceTimeLeft(setup.Duration)
                : _statusFactory.CreateStatus(setup, targetId, producerId)
                    .With(x => x.isApplied = true);
        }
    }
}