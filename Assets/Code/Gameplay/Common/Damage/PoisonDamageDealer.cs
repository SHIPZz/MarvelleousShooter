using System.Threading;
using Code.Gameplay.Healths;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Gameplay.Common.Damage
{
    public class PoisonDamageDealer : MonoBehaviour
    {
        private float _damage = 3f;
        private float _duration = 5f;
        private float _period = 1f;
        
        private CancellationTokenSource _cancellationToken = new();
        private bool _isPoisoning;
        private DamageDealer _damageDealer;

        private void Awake()
        {
            _damageDealer = GetComponent<DamageDealer>();
        }

        private void OnEnable()
        {
            _cancellationToken = new CancellationTokenSource();
            _damageDealer.TargetDamaged += DoPoison;
        }

        private void OnDisable()
        {
            _cancellationToken?.Dispose();
            _damageDealer.TargetDamaged -= DoPoison;
        }

        public void Init(float damage, float duration)
        {
            _duration = duration;
            _damage = damage;
        }

        private async void DoPoison(Health target)
        {
            if (target == null)
                return;

            if (target.Value <= 0 || _isPoisoning)
                return;

            _isPoisoning = true;

            while (target.Value > 0 && _duration > 0)
            {
                target.Decrease(_damage);

                await UniTask.WaitForSeconds(_period, false, PlayerLoopTiming.Update, _cancellationToken.Token);

                _duration -= 1f;
            }

            _isPoisoning = false;
        }
    }
}