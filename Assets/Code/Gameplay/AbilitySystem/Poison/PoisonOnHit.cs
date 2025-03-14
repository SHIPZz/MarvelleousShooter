using System.Threading;
using Code.Gameplay.Healths;
using Cysharp.Threading.Tasks;
using ECM.Common;
using UnityEngine;

namespace Code.Gameplay.AbilitySystem.Poison
{
    public class PoisonOnHit : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private CancellationTokenSource _cancellationToken = new();
        private float _damage;
        private float _duration;


        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.ValueChanged += DoPoison;
        }

        private void OnDisable()
        {
            _health.ValueChanged -= DoPoison;
        }
        
        public void Init(float damage, float duration)
        {
            _duration = duration;
            _damage = damage;
        }

        private async void DoPoison(float hp)
        {
            if(hp.isZero())
                return;

            while (_health.Value > 0 || _duration > 0)
            {
                _health.Decrease(_damage);
                
                await UniTask.WaitForSeconds(_duration, false, PlayerLoopTiming.Update, _cancellationToken.Token);
                
                _duration -= 1f;
            }
        }
    }
}