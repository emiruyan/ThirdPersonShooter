using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.Combats;
using UnityEngine;

namespace ThirdPersonShooter.ScriptableObjects
{
    enum AttackTypeEnum : byte 
    {
        Range,Melee
    }
    
    [CreateAssetMenu(fileName = "Attack Info",menuName = "AttackInformation/Create New",order = 51)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] private AttackTypeEnum _attackType;
        [SerializeField] int _damage = 10; 
        [SerializeField] float _floatValue = 1f;
        [SerializeField] float _attackMaxDelay = 0.25f;
        [SerializeField] LayerMask _layerMask;
        public int Damage => _damage;
        public float FloatValue => _floatValue; 
        public LayerMask LayerMask => _layerMask;
        public float AttackMaxDelay => _attackMaxDelay;

        public IAttackType GetAttackType(Transform transform)
        {
            if (_attackType==AttackTypeEnum.Range)
            {
                return new RangeAttackType(transform, this);
            }
            else
            {
                return new MeleeAttackType(transform, this);
            }
        }
         

    }
}


