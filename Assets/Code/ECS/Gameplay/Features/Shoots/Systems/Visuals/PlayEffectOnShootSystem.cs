﻿using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Visuals
{
    public class PlayEffectOnShootSystem : ReactiveSystem<GameEntity>
    {
        public PlayEffectOnShootSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Shooting.Added());

        protected override bool Filter(GameEntity entity) => entity.isGun
                                                             && entity.isShooting
                                                             && entity.isActive
                                                             && entity.hasEffectPlayer;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gun in entities)
            {
                gun.EffectPlayer.Play();
            }
        }
    }
}