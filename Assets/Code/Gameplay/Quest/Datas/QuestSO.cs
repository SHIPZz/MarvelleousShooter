using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Resource;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Gameplay.Quest.Datas
{
    [CreateAssetMenu(fileName = "QuestSO", menuName = "Gameplay/QuestSO", order = 1)]
    public class QuestSO : SerializedScriptableObject
    {
        public QuestTypeId QuestTypeId;
        public int Id;
        public string Description;
        
        [Space]
        public List<ResourceData> Rewards;
        
        [Space]
        public int AmountToComplete;

        [Button]
        public void GenerateId()
        {
            var allQuests = Resources.LoadAll<QuestSO>("Configs/Quests")
                .ToList();
            
            var lastQuestBySameType = allQuests.Last(x => x.QuestTypeId == QuestTypeId);

            if (lastQuestBySameType == null || allQuests.Count == 1)
            {
                Id = 1;
                return;
            }

            Id = ++lastQuestBySameType.Id;
            
            var questWithSameId = allQuests.Find(x => x.Id == Id && Description != x.Description);

            if (questWithSameId != null)
                Id++;
        }
    }
}