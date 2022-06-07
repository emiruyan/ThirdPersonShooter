
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace  ThirdPersonShooter.Combats
{
    public class Health : MonoBehaviour , IHealth
    {
        [SerializeField] HealthSO _healthInfo;
        
        int _currentHealth;
        public event System.Action<int, int> OnTakeHit;
        public event System.Action OnDead;

        public bool IsDead => _currentHealth <= 0;

        void Awake()
        {
            _currentHealth = _healthInfo.MaxHealth; 
        }

        

        public void TakeDamage(int damage)
        {
            if (IsDead) return;
            
            _currentHealth -= damage;
            
            OnTakeHit?.Invoke(_currentHealth, _healthInfo.MaxHealth);

            if (IsDead)
            {
                OnDead?.Invoke(); 
            }
            
        }
    }

}

