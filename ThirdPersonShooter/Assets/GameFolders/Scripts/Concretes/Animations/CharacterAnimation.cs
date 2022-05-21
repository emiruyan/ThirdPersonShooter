using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Controllers;
using UnityEngine;

namespace ThirdPersonShooter.Animations
{
    public class CharacterAnimation
    { 
        Animator _animator;

        public CharacterAnimation(PlayerController entity)
        {
            _animator = entity.GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(float moveSpeed)
        {
            if (_animator.GetFloat("moveSpeed") == moveSpeed) return;
           
            
            _animator.SetFloat("moveSpeed", moveSpeed,  0.1f,Time.deltaTime);
        }
    }
}


