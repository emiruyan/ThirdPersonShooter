using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace ThirdPersonShooter.Combats
{
    public class RangeAttackType : IAttackType
    {
        private Camera _camera;
        private AttackSO _attackSo;
           
        
        public RangeAttackType(Transform transformObject,AttackSO attackSo)
        {
            _camera = transformObject.GetComponent<Camera>();
            _attackSo = attackSo;




        }
        
        public void AttackAction()
        {
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);
            //Ray ray = _camera.ScreenPointToRay(_crossHair.transform.position);
            
            if (Physics.Raycast(ray,out RaycastHit hit,_attackSo.FloatValue, _attackSo.LayerMask)) 
            { 
                 IHealth health = hit.collider.GetComponent<IHealth>();
                
                if (health != null)   
                {
                    health.TakeDamage(_attackSo.Damage);
                }
                
            }
        }
    }
}


