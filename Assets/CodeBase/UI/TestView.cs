using CodeBase.Data.Services;
using CodeBase.Gameplay.AbilitySystem;
using CodeBase.Gameplay.Quest.Datas;
using CodeBase.Gameplay.Quest.Services;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.UI
{
    public class TestView : MonoBehaviour
    {
        public int Count = 1;
        public QuestTypeId QuestTypeId;

        private IQuestService _questService;
        private IWorldDataService _worldDataService;
        private IAbilityService _abilityService;

        [Inject]
        private void Construct(IQuestService questService, IWorldDataService worldDataService, IAbilityService abilityService)
        {
            _abilityService = abilityService;
            _worldDataService = worldDataService;
            _questService = questService;
        }

        private void Start()
        {
            // CreateAbility(AbilityTypeId.Poison, EnemyTypeId.None);
        }

        [Button]
        public void CreateAbility(AbilityTypeId abilityTypeId, AbilityOwnerTypeId abilityOwnerTypeId)
        {
            // _abilityService.Start<TemporaryIncreaseDamageAbility>();
        }
        
        [Button]
        public void DestroyAbility(AbilityTypeId abilityTypeId)
        {
            _abilityService.Stop(abilityTypeId);
            // _abilityService.StopShoot(abilityTypeId, targetLayer);
        }


        [Button]
        public void GetQuest()
        {
            QuestData currentQuestByType = _questService.GetCurrentQuestByType(QuestTypeId);

            print($"{currentQuestByType.Id}\n" +
                  $" {currentQuestByType.Description}" +
                  $" {currentQuestByType.ProgressTypeId.ToString()}" +
                  $" {currentQuestByType.Progress} - progress");
        }
        
        [Button]
        public void ResetData()
        {
            _worldDataService.Reset();
        }

        [Button]
        public void UpdateQuest(int amount)
        {
            _questService.UpdateQuest(QuestTypeId, amount);

            GetQuest();
        }
    }
}