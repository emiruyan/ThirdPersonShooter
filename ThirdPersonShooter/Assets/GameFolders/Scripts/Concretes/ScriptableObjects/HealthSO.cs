using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonShooter.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Health Info", menuName = "Combat/Health Information/Create New")]
    public class HealthSO : ScriptableObject
    {
        [SerializeField] int _maxHealth;

        public int MaxHealth => _maxHealth;
    }
}


