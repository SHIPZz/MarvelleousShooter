using System.Collections;
using System.Collections.Generic;
using Code.ECS.Common.Services;
using Code.ECS.Extensions;
using Code.ECS.Gameplay.Features.Loot;
using Code.ECS.Gameplay.Features.Loot.Factory;
using Code.ECS.Gameplay.Features.Statuses;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.ECS.Gameplay.Features.Pull.Systems
{
    public class PullTestView : MonoBehaviour
    {
        public AnimationCurve AnimationCurve;
        
        public int MaxPullTargets = 5;
        public int MinPullTargets = 1;
        public CollisionLayer Layer;
        public float PullInRadius = 3f;
        public List<StatusSetup> StatusSetups;
        private IIdentifierService _identifierService;

        [SerializeField] private float _createTime;

        public LootTypeId LootTypeId;

        [SerializeField] private float _lastTime;
        private ILootFactory _lootFactory;
        public float ScaleFactor = 1.5f;
       [SerializeField] private float _animationDuration  = 1f;

        [Inject]
        private void Construct(IIdentifierService identifierService, ILootFactory lootFactory)
        {
            _lootFactory = lootFactory;
            _identifierService = identifierService;
        }

        private void Awake()
        {
            // CreateEntity.Empty()
            //     .AddId(_identifierService.Next())
            //     .AddMinCountToPullTargets(MinPullTargets)
            //     .AddTargetsBuffer(new List<int>(32))
            //     .AddPullTargetLayerMask(Layer.AsMask())
            //     .AddPullInRadius(PullInRadius)
            //     .AddStatusSetups(new List<StatusSetup>())
            //     .With(x => x.AddStatusSetups(StatusSetups))
            //     .AddWorldPosition(transform.position)
            //     .With(x => x.AddPullTargetList(new List<int>(32)))
            //     .With(x => x.isPullingDetector = true)
            //     .With(x => x.isPullTargetHolder = true)
            //     ;
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2f); 

            float elapsedTime = 0f;

            Vector3 startPosition = transform.position;

            while (elapsedTime < _animationDuration) 
            {
                elapsedTime += Time.deltaTime;

                float normalizedTime = (elapsedTime % _animationDuration) / _animationDuration;

                float yOffset = AnimationCurve.Evaluate(normalizedTime) * ScaleFactor;

                transform.position = new Vector3(
                    startPosition.x,
                    startPosition.y + yOffset, 
                    startPosition.z
                );

                yield return null;
            }
        }

        private void Update()
        {
            if (_createTime == 0)
                return;

            _lastTime += Time.deltaTime;

            if (_lastTime >= _createTime)
            {
                Vector2 randomOffset = Random.insideUnitCircle * 15f;
                Vector3 spawnPosition = new Vector3(
                    transform.position.x + randomOffset.x,
                    transform.position.y,
                    transform.position.z + randomOffset.y
                );

                _lootFactory.CreateLootItem(LootTypeId, spawnPosition);
                _lastTime = 0f;
            }
        }
    }
}