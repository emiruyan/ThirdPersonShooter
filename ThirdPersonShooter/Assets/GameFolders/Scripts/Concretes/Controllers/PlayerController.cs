using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Inputs;
using UnityEngine;

namespace ThirdPersonShooter.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private IInputReader _input;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
        } 

        private void Update()
        { 
            Debug.Log((_input.Direction));
        }
    }
}


