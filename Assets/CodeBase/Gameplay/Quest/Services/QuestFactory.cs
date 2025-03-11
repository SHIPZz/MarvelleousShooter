using System;
using CodeBase.Gameplay.Common.Progress;
using CodeBase.Gameplay.Quest.Datas;
using Zenject;

namespace CodeBase.Gameplay.Quest.Services
{
    public interface IQuestFactory
    {
        QuestData Create(int id, QuestTypeId questTypeId, int progress = 0,
            ProgressTypeId progressTypeId = ProgressTypeId.Started);

        T CreateQuestSystem<T>() where T : IQuestSystem;
    }

    public class QuestFactory : IQuestFactory
    {
        private readonly IQuestStaticDataService _questStaticDataService;
        private IQuestFactory _questFactoryImplementation;
        private IInstantiator _instantiator;

        public QuestFactory(IQuestStaticDataService questStaticDataService, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _questStaticDataService = questStaticDataService;
        }

        public QuestData Create(int id, QuestTypeId questTypeId, int progress = 0,
            ProgressTypeId progressTypeId = ProgressTypeId.Started)
        {
            QuestSO targetQuest = _questStaticDataService.GetTargetQuest(questTypeId, id);

            if (targetQuest == null)
                throw new ArgumentException($"There is no quest so with id - {id}");

            return QuestData.Create(id, questTypeId, 0f, 0f, targetQuest.Description, progress, progressTypeId);
        }

        public T CreateQuestSystem<T>() where T : IQuestSystem
        {
            return _instantiator.Instantiate<T>();
        }
    }
}