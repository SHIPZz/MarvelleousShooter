using UnityEngine;

namespace Code.ECS.Gameplay.Features.Cameras.Factories
{
    public interface ICameraFactory
    {
        void CreateEntity(Camera camera);
    }
}