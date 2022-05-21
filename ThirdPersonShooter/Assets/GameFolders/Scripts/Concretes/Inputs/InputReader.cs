using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ThirdPersonShooter.Inputs
{
    public class InputReader : MonoBehaviour, IInputReader
    {
        public Vector3 Direction { get; private set; }
        public Vector2 Rotation { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
          Vector2 oldDirection = context.ReadValue<Vector2>();
          Direction = new Vector3(oldDirection.x, 0f, oldDirection.y);
        }

        public void OnRotator(InputAction.CallbackContext context)
        {
            Rotation = context.ReadValue<Vector2>();
        }
    }
}


