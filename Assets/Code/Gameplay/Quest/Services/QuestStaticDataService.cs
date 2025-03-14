using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Quest.Datas;
using UnityEngine;

namespace Code.Gameplay.Quest.Services
{
    public interface IQuestStaticDataService
    {
        IReadOnlyList<QuestSO> GetAllQuests();
        QuestSO GetExploreZoneQuests(int id);
        QuestSO GetCollectItemsQuest(int id);
        QuestSO GetEnemyQuest(int id);
        QuestSO GetTargetQuest(QuestTypeId questTypeId, int id);
    }

    public class QuestStaticDataService : IQuestStaticDataService
    {
        private readonly IEnumerable<QuestSO> _enemyKillQuests;
        private readonly IEnumerable<QuestSO> _exploreZoneQuests;
        private readonly IEnumerable<QuestSO> _collectItemsQuests;
        
        private readonly List<QuestSO> _allQuests;
        private readonly IEnumerable<QuestSO> _killEnemyPiercing;

        public QuestStaticDataService()
        {
            _allQuests = Resources.LoadAll<QuestSO>("Configs/Quests").ToList();
            
            _enemyKillQuests =  _allQuests.Where(x => x.QuestTypeId == QuestTypeId.KillEnemy);
            
            _exploreZoneQuests =  _allQuests.Where(x => x.QuestTypeId == QuestTypeId.ExploreZone);
            
            _collectItemsQuests =  _allQuests.Where(x => x.QuestTypeId == QuestTypeId.CollectItems);
            
            _killEnemyPiercing =  _allQuests.Where(x => x.QuestTypeId == QuestTypeId.KillEnemyPiercing);
        }

        public IReadOnlyList<QuestSO> GetAllQuests()
        {
            IReadOnlyList<QuestSO> quest = _allQuests;

            return quest;
        }
        
        public QuestSO GetExploreZoneQuests(int id)
        {
            foreach (var quest in _exploreZoneQuests)
            {
                if (quest.Id == id)
                    return quest;
            }

            return null;
        }
        
        public QuestSO GetCollectItemsQuest(int id)
        {
            foreach (var quest in _collectItemsQuests)
            {
                if (quest.Id == id)
                    return quest;
            }

            return null;
        }
        
        public QuestSO GetEnemyQuest(int id)
        {
            foreach (var quest in _enemyKillQuests)
            {
                if (quest.Id == id)
                    return quest;
            }

            return null;
        }

        public QuestSO GetTargetQuest(QuestTypeId questTypeId, int id)
        {
            switch (questTypeId)
            {
                case QuestTypeId.KillEnemy:
                    return _enemyKillQuests.FirstOrDefault(x => x.QuestTypeId == questTypeId && x.Id == id);
                
                case QuestTypeId.CollectItems:
                    return _collectItemsQuests.FirstOrDefault(x => x.QuestTypeId == questTypeId && x.Id == id);
                
                case QuestTypeId.KillEnemyPiercing:
                    return _killEnemyPiercing.FirstOrDefault(x => x.QuestTypeId == questTypeId && x.Id == id);
                
                default:
                    return null;
            }
        }
    }
}