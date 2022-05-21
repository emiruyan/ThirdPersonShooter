using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Inputs;
using ThirdPersonShooter.Abstracts.Movements;
using ThirdPersonShooter.Animations;
using ThirdPersonShooter.Movements;
using UnityEngine;

namespace ThirdPersonShooter.Controllers
{
    public class PlayerController : MonoBehaviour
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
        
        Vector3 _direction;
       

        public Transform TurnTransform => _turnTransform;
        

        

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
        } 

        void Update()
        {
            _direction = _input.Direction;
            
            
            _xRotator.RotationAction(_input.Rotation.x,_turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y,_turnSpeed);
        }

        void FixedUpdate()
        {
             _mover.MoveAction(_direction, _moveSpeed);
            
        }

        private void LateUpdate()
        {
             _animation.MoveAnimation(_direction.magnitude);
        }
    }
}


