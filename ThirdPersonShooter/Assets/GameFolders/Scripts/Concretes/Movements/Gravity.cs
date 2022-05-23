using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ThirdPersonShooter.Movements
{
    public class Gravity : MonoBehaviour
    {
        [SerializeField] float _gravity;
        CharacterController _characterController;
        private Vector3 velocity;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (_characterController.isGrounded) velocity.y = 0f;
            velocity.y += _gravity * Time.deltaTime;
            _characterController.Move(velocity * Time.deltaTime);


        }
    }

}
