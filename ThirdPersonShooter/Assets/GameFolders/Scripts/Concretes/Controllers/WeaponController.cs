using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.Combats;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace ThirdPersonShooter.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        
        [SerializeField] bool _canFire;
        
        [SerializeField] Transform  _transformObject;
        [SerializeField] private AttackSO _attackSo;
        
        
        
        
        //public GameObject _crossHair;
        

        
        private float _currentTime = 0f;
        private IAttackType _attackType;

        private void Awake()
        {
            _attackType = new RangeAttackType(_transformObject, _attackSo);
        }

        private void Update()
        { 
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackSo.AttackMaxDelay;

        }

        public void Attack()
        {
            if (!_canFire) return;

            
            _attackType.AttackAction(); 

            _currentTime = 0f;
        }
    }
}



