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

        public void MoveAnimations()
        {
        }
    }
}


