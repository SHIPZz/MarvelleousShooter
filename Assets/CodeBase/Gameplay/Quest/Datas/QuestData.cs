using System;
using CodeBase.Extensions;
using CodeBase.Gameplay.Common.Progress;

namespace CodeBase.Gameplay.Quest.Datas
{
    [Serializable]
    public class QuestData
    {
        public int Id;
        public string Description;
        public float StartTime;
        public float TimeToFinish;
        
        public QuestTypeId QuestTypeId;
        public ProgressTypeId ProgressTypeId;

        public int Progress;
        
        public static QuestData Create(int id, QuestTypeId questTypeId, 
            float startTime, 
            float timeToFinish,
            string description,
            int progress = 0, 
            ProgressTypeId progressTypeId = ProgressTypeId.Started)
        {
           var data = new QuestData
           {
               QuestTypeId = questTypeId,
               Id = id,
               StartTime = startTime,
               TimeToFinish = timeToFinish,
               Description = description,
               ProgressTypeId = progressTypeId
           };
           
           return data.With(x => x.Progress += progress);
        }
    }
}