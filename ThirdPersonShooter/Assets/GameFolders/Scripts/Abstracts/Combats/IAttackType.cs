using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace ThirdPersonShooter.Abstracts.Combats
{
    public interface IAttackType    
    {
        void AttackAction();
        public AttackSO AttackInfo { get; }
    }
}


