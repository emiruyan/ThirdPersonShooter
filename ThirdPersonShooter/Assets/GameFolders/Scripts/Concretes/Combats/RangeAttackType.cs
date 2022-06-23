using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.Controllers;
using ThirdPersonShooter.Managers;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace ThirdPersonShooter.Combats
{
    public class RangeAttackType : MonoBehaviour, IAttackType
    {
        [SerializeField] AttackSO _attackSo;
        [SerializeField] Camera _camera;
        [SerializeField] BulletFxController _bulletFx;
        [SerializeField] Transform _bulletPoint;
        
        public AttackSO AttackInfo => _attackSo;

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

            var bullet = Instantiate(_bulletFx, _bulletPoint.position, _bulletPoint.rotation);
            bullet.SetDirection(ray.direction);
            
            SoundManager.Instance.RangeAttackSound(_attackSo.Clip,_camera.transform.position);
        }

        
    }
}


