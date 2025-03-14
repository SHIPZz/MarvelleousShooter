using Code.ECS.Common.Services;
using Code.ECS.Entity;
using UnityEngine;
using Zenject;

namespace Code.ECS.View
{
    public class SelfInitializeEntityView : MonoBehaviour
    {
        public EntityBehaviour EntityBehaviour;
        private IIdentifierService _identifierService;

        [Inject]
        private void Construct(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        private void Awake()
        {
            EntityBehaviour.SetEntity(CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
            );
        }
    }
}