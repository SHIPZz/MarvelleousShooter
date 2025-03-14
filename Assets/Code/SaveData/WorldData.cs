using System;
using System.Collections.Generic;
using Code.Gameplay.Quest.Datas;
using Sirenix.Serialization;

namespace Code.SaveData
{
    [Serializable]
    public class WorldData
    {
        [OdinSerialize] public Dictionary<QuestTypeId, int> CurrentQuestIds = new();

        public List<QuestData> Quests = new List<QuestData>();
        public PlayerData PlayerData = new PlayerData();

        public bool TryGetCurrentQuestId(QuestTypeId questTypeId, out int id)
        {
            return CurrentQuestIds.TryGetValue(questTypeId, out id);
        }
        
        public QuestData GetQuest(QuestTypeId questTypeId)
        {
            int targetId = CurrentQuestIds[questTypeId];
            
            foreach (var quest in Quests)
            {
                if (quest.Id == targetId && quest.QuestTypeId == questTypeId)
                    return quest;
            }

            return null;
        }

        public void UpdateCurrentQuestId(QuestTypeId questTypeId) => CurrentQuestIds[questTypeId]++;

        public void UpdateQuest(QuestData questData)
        {
            for (int i = 0; i < Quests.Count; i++)
            {
                if (Quests[i].Id == questData.Id && Quests[i].QuestTypeId == questData.QuestTypeId)
                {
                    Quests[i] = questData;
                    return;
                }
            }

            Quests.Add(questData);
        }

    }
}