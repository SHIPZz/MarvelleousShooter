using UnityEngine;

namespace Code.ECS.Gameplay.Features.Cameras.Factories
{
    public interface ICameraFactory
    {
        GameEntity CreateEntity(Camera camera);
    }
}