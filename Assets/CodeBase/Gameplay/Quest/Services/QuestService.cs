using System;
using System.Collections.Generic;
using CodeBase.Data.Services;
using CodeBase.Extensions;
using CodeBase.Gameplay.Common.Progress;
using CodeBase.Gameplay.Quest.Datas;
using CodeBase.SaveData;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Quest.Services
{
    public interface IQuestService
    {
        void UpdateQuest(QuestTypeId questTypeId, int amount);
        QuestData GetCurrentQuestByType(QuestTypeId questTypeId);
        int GetAmountToComplete(QuestTypeId questTypeId);
        int GetCurrentProgress(QuestTypeId killEnemyPiercing);
    }

    public class QuestService : IInitializable, IDisposable, IQuestService
    {
        private readonly IWorldDataService _worldDataService;
        private readonly IQuestStaticDataService _questStaticDataService;
        private readonly IQuestFactory _questFactory;
        
        private Dictionary<QuestTypeId, IQuestSystem> _questSystems = new();

        public QuestService(IWorldDataService worldDataService,
            IQuestStaticDataService questStaticDataService,
            IQuestFactory questFactory)
        {
            _questFactory = questFactory;
            _questStaticDataService = questStaticDataService;
            _worldDataService = worldDataService;
        }

        public void Initialize()
        {
            WorldData worldData = _worldDataService.Get();

            foreach (var questData in worldData.Quests)
            {
                if (questData.ProgressTypeId == ProgressTypeId.Started)
                    CreateSystemByType(questData.QuestTypeId);
            }
        }

        public void Dispose()
        {
            foreach (IQuestSystem questSystem in _questSystems.Values)
            {
                questSystem?.Dispose();
            }
        }

        private void CreateSystemByType(QuestTypeId questTypeId)
        {
            Debug.Log($"{questTypeId} - system created");
            
            switch (questTypeId)
            {
                case QuestTypeId.KillEnemyPiercing:
                    var quest = _questFactory.CreateQuestSystem<KillEnemyPiercingQuestSystem>().With(x => x.Init());
                    _questSystems[QuestTypeId.KillEnemyPiercing] = quest;
                    break;
            }
        }

        public int GetAmountToComplete(QuestTypeId questTypeId)
        {
            WorldData worldData = _worldDataService.Get();
            
            int id = worldData.CurrentQuestIds[questTypeId];
            
           return _questStaticDataService.GetTargetQuest(questTypeId, id).AmountToComplete;
        }

        public int GetCurrentProgress(QuestTypeId questTypeId)
        {
            WorldData worldData = _worldDataService.Get();
            
            return worldData.GetQuest(questTypeId).Progress;
        }

        public QuestData GetCurrentQuestByType(QuestTypeId questTypeId)
        {
            WorldData worldData = _worldDataService.Get();

            if (!worldData.TryGetCurrentQuestId(questTypeId, out int id))
            {
                CreateSystemByType(questTypeId);
                return CreateAndSaveQuest(questTypeId, id: 1, progress: 0, worldData);
            }

            if (worldData.GetQuest(questTypeId) == null)
            {
                CreateSystemByType(questTypeId);
                return CreateAndSaveQuest(questTypeId, id, 0, worldData);
            }

            return worldData.GetQuest(questTypeId).With(_ => SetCompletedOnProgressCompleted(questTypeId, id));
        }

        private QuestData CreateAndSaveQuest(QuestTypeId questTypeId, int id, int progress, WorldData worldData)
        {
            QuestData quest = _questFactory.Create(id, questTypeId, progress);

            worldData.Quests.Add(quest);
            worldData.CurrentQuestIds[questTypeId] = id;
            _worldDataService.Save(worldData);
            return quest;
        }

        public void UpdateQuest(QuestTypeId questTypeId, int amount)
        {
            WorldData worldData = _worldDataService.Get();

            if (!worldData.TryGetCurrentQuestId(questTypeId, out int currentQuestIdByType))
            {
                CreateAndSaveQuest(questTypeId, id: 1, amount, worldData);
                return;
            }

            if (_questStaticDataService.GetTargetQuest(questTypeId, currentQuestIdByType) == null)
                return;

            QuestData targetQuest = worldData.GetQuest(questTypeId);

            if (targetQuest == null)
            {
                CreateAndSaveQuest(questTypeId, currentQuestIdByType, amount, worldData);
                return;
            }

            targetQuest
                .With(x => x.Progress += amount)
                .With(x => worldData.UpdateQuest(x));
            
            SetCompletedOnProgressCompleted(questTypeId, currentQuestIdByType);

            _worldDataService.Save(worldData);
        }

        private void SetCompletedOnProgressCompleted(QuestTypeId questTypeId, int id)
        {
            int amountToComplete = _questStaticDataService
                .GetTargetQuest(questTypeId, id)
                .AmountToComplete;

            WorldData worldData = _worldDataService.Get();

            QuestData questData = worldData.GetQuest(questTypeId);

            questData
                .With(apply: x => x.ProgressTypeId = ProgressTypeId.Completed,
                    when: x => amountToComplete == x.Progress)
                .With(apply: x => worldData.UpdateCurrentQuestId(questTypeId),
                    when: x => x.ProgressTypeId == ProgressTypeId.Completed)
                ;

            RemoveSystemOnCompleted(questTypeId, questData);

            _worldDataService.Save(worldData);
        }

        private void RemoveSystemOnCompleted(QuestTypeId questTypeId, QuestData questData)
        {
            if (questData.ProgressTypeId == ProgressTypeId.Completed && _questSystems.ContainsKey(questTypeId))
            {
                _questSystems[questTypeId].Dispose();
                _questSystems.Remove(questTypeId);
            }
        }
    }
}