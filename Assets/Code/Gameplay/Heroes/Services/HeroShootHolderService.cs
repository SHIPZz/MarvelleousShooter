using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Code.Gameplay.Heroes.Enums;
using Code.Gameplay.Shootables;
using Code.Gameplay.Shootables.Services;

namespace Code.Gameplay.Heroes.Services
{
    public class HeroShootHolderService : IHeroShootHolderService, IDisposable
    {
        private readonly Dictionary<ShootTypeId, Shoot> _activeShoots = new();
        private readonly IShootService _shootService;
        private CancellationTokenSource _cancellationToken = new();
        private Shoot _currentShoot => _shootService.CurrentShoot;

        public HeroShootHolderService(IShootService shootService)
        {
            _shootService = shootService;
        }

        public void Add(Shoot shoot)
        {
            _activeShoots[shoot.Id] = shoot;
        }

        public void Remove(Shoot shoot)
        {
            _activeShoots.Remove(shoot.Id);
        }

        public bool TryGetShoot(GunInputTypeId gunInputTypeId, out Shoot shoot)
        {
            shoot = _activeShoots.Values.FirstOrDefault(x => x.ShowInputKey == gunInputTypeId);

            return shoot != null;
        }

        public bool IsAlreadyActive(Shoot shoot)
        {
            return _currentShoot != null && _currentShoot.Id == shoot.Id;
        }

        public void Dispose()
        {
            _cancellationToken?.Dispose();
        }
    }
}