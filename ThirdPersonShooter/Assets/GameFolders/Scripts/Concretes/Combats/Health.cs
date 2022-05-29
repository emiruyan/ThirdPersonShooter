using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace  ThirdPersonShooter.Combats
{
    public class Health : MonoBehaviour , IHealth
    {
        [SerializeField] HealthSO _healthInfo;
        
        int _currentHealth;

        public bool IsDead => _currentHealth <= 0;

        void Awake()
        {
            _currentHealth = _healthInfo.MaxHealth; 
        }

        

        public void TakeDamage(int damage)
        {
            if (IsDead) return;
            
            _currentHealth -= damage;
        }
    }

}

