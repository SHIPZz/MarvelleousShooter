using CodeBase.Gameplay.Common;
using CodeBase.Gameplay.Common.Damage;
using CodeBase.Gameplay.Healths;
using CodeBase.Gameplay.Heroes;
using CodeBase.Gameplay.Quest.Datas;
using UnityEngine;

namespace CodeBase.Gameplay.Quest.Services
{
    public class KillEnemyPiercingQuestSystem : IQuestSystem
    {
        private readonly IQuestService _questService;
        private IDamageNotifierService _damageNotifierService;

        public KillEnemyPiercingQuestSystem(IDamageNotifierService damageNotifierService, IQuestService questService)
        {
            _damageNotifierService = damageNotifierService;
            _questService = questService;
        }

        public void Init()
        {
            _damageNotifierService.OnTargetPiercingDamaged += CheckAndCountDeath;
        }

        public void Dispose()
        {
            Debug.Log($"Quest completed - {nameof(KillEnemyPiercingQuestSystem)}");
            _damageNotifierService.OnTargetPiercingDamaged -= CheckAndCountDeath;
        }

        private void CheckAndCountDeath(Health health)
        {
            if (health.gameObject.layer == LayerId.Enemy && health.Dead)
            {
                Debug.Log($"Quest updated - {nameof(KillEnemyPiercingQuestSystem)}");
                _questService.UpdateQuest(QuestTypeId.KillEnemyPiercing, 1);
            }
        }
    }
}