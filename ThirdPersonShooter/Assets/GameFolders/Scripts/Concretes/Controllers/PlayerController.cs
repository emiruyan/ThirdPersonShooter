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
        [Header("Movement Informations")] [SerializeField]
        float _moveSpeed = 10f;
        
        IInputReader _input; 
        IMover _mover;
        CharacterAnimation _animation;
        Vector3 _direction;

        

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
        } 

        void Update()
        {
            _direction = _input.Direction;
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


