using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.Abstracts.Controllers;
using ThirdPersonShooter.Abstracts.Inputs;
using ThirdPersonShooter.Abstracts.Movements;
using ThirdPersonShooter.Animations;
using ThirdPersonShooter.Managers;
using ThirdPersonShooter.Movements;
using UnityEngine;

namespace ThirdPersonShooter.Controllers
{
    public class PlayerController : MonoBehaviour , IEntityController
    {
        [Header("Movement Informations")] 
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] Transform _turnTransform;

        [Header("Uis")] 
        [SerializeField] GameObject _gameOverPanel;
        
        
        IInputReader _input;
        IHealth _health;
        IMover _mover;
        IRotator _xRotator;
        IRotator _yRotator;
        CharacterAnimation _animation;
        InventoryController _ınventory;
        
        Vector3 _direction;
       

        public Transform TurnTransform => _turnTransform;
            
        
        

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _health = GetComponent<IHealth>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
            _ınventory = GetComponent<InventoryController>();
        }

        private void OnEnable()
        {
            _health.OnDead += () =>
            {
                _animation.DeadAnimation("death");
                _gameOverPanel.SetActive(true);
            };
            
            EnemyManager.Instance.Targets.Add(this.transform);
        }

        private void OnDisable()
        {
            EnemyManager.Instance.Targets.Remove(this.transform);
        }

        void Update()
        {
            if (_health.IsDead) return;

            _direction = _input.Direction;
            
            
            _xRotator.RotationAction(_input.Rotation.x,_turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y,_turnSpeed);

           
            
            if (_input.IsAttackButtonPress)
            {
                _ınventory.CurrentWeapon.Attack();
            }

            if (_input.IsInventoryButtonPressed)
            { 
                _ınventory.ChangeWeapon();
            }
        }

        void FixedUpdate()
        {
            if (_health.IsDead) return;
            
            _mover.MoveAction(_direction, _moveSpeed);
            
        }

        private void LateUpdate()
        {
            if (_health.IsDead) return;  

            _animation.MoveAnimation(_direction.magnitude);
            _animation.AttackAnimation(_input.IsAttackButtonPress); 
        }
    }
}


