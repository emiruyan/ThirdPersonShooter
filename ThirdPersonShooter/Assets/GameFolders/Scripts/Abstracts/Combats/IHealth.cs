using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonShooter.Abstracts.Combats
{
    public interface IHealth 
    {
        public bool IsDead { get; }
         void TakeDamage(int damage);
         event System.Action OnDead;
    }
}


