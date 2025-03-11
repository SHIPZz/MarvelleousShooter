using CodeBase.Gameplay.Heroes.Enums;
using CodeBase.Gameplay.Shootables;

namespace CodeBase.Gameplay.Heroes.Services
{
    public interface IHeroShootHolderService
    {
        void Add(Shoot shoot);
        void Remove(Shoot shoot);
        bool TryGetShoot(ShootInputTypeId shootInputTypeId, out Shoot shoot);
        bool IsAlreadyActive(Shoot shoot);
    }
}