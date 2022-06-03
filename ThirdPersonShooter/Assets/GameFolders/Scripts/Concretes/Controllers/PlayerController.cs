using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Controllers;
using ThirdPersonShooter.Abstracts.Inputs;
using ThirdPersonShooter.Abstracts.Movements;
using ThirdPersonShooter.Animations;
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
        
        
        IInputReader _input; 
        IMover _mover;
        IRotator _xRotator;
        IRotator _yRotator;
        CharacterAnimation _animation;
        private InventoryController _ınventory;
        
        Vector3 _direction;
       

        public Transform TurnTransform => _turnTransform;
            
        

        

        private void Awake()
        {
            _input = GetComponent<IInputReader>(); 
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
            _ınventory = GetComponent<InventoryController>();
        } 

        void Update()
        {
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
            _mover.MoveAction(_direction, _moveSpeed);
            
        }

        private void LateUpdate()
        {
             _animation.MoveAnimation(_direction.magnitude);
             _animation.AttackAnimation(_input.IsAttackButtonPress); 
        }
    }
}


