using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Movements;
using ThirdPersonShooter.Controllers;
using UnityEngine;

namespace ThirdPersonShooter.Movements
{
    public class RotatorX : IRotator
    {
        private PlayerController _playerController;

        public RotatorX(PlayerController playerController)
        {
            _playerController = playerController;

        }
        public void RotationAction(float direction, float speed)
        {
            _playerController.transform.Rotate(Vector3.up * direction* Time.deltaTime* speed);
        }
    }
}


