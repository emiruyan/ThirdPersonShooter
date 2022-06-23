using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.Managers;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace ThirdPersonShooter.Combats
{
    public class MeleeAttackType :MonoBehaviour, IAttackType
    {
        [SerializeField] Transform _transformObject;
        [SerializeField] AttackSO _attackSo;
        public AttackSO AttackInfo => _attackSo;
        
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
            
            SoundManager.Instance.MeleeAttackSound(_attackSo.Clip,_transformObject.position);
        }

        
    }
}


