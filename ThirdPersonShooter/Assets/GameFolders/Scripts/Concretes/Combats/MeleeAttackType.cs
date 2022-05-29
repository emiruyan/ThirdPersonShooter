using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace ThirdPersonShooter.Combats
{
    public class MeleeAttackType :IAttackType
    {
        private Transform _transformObject;
        private AttackSO _attackSo;
        
        public MeleeAttackType(Transform transformObject, AttackSO attackSo)
        {
            _transformObject = transformObject;
            _attackSo = attackSo;
        }
        
        public void AttackAction()
        {
            Vector3 attackPoint = _transformObject.position;
            Collider[] colliders = Physics.OverlapSphere(attackPoint, _attackSo.FloatValue, _attackSo.LayerMask);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSo.Damage);
                }
            }
        }
    }
}


