﻿namespace Code.ECS.Gameplay.Features.Statuses.Applier
{
    public interface IStatusApplier
    {
        GameEntity ApplyStatus(StatusSetup setup, int producerId, int targetId);
    }
}