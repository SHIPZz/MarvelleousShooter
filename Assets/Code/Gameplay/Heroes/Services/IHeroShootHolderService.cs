using Code.Gameplay.Heroes.Enums;
using Code.Gameplay.Shootables;

namespace Code.Gameplay.Heroes.Services
{
    public interface IHeroShootHolderService
    {
        void Add(Shoot shoot);
        void Remove(Shoot shoot);
        bool TryGetShoot(ShootInputTypeId shootInputTypeId, out Shoot shoot);
        bool IsAlreadyActive(Shoot shoot);
    }
}