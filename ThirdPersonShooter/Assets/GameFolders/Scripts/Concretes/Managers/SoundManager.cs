using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Helpers;
using ThirdPersonShooter.Controllers;
using UnityEngine;

namespace ThirdPersonShooter.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField] AudioClip _clip;

        SoundController[] _soundControllers;
             
        
        private void Awake()
        {
            SetSingletonThisGameObject(this);
            _soundControllers = GetComponentsInChildren<SoundController>();
        }

        private void Start()
        {
            _soundControllers[0].SetClip(_clip);
            _soundControllers[0].PlaySound(Vector3.zero);
        }

        public void RangeAttackSound(AudioClip clip, Vector3 position)  
        {
            _soundControllers[1].PlaySound(position);
            _soundControllers[1].SetClip(clip);
        }
        
        public void MeleeAttackSound(AudioClip clip, Vector3 positon)
        {
            for (int i = 2; i < _soundControllers.Length; i++)
            {
                if (_soundControllers[i].IsPlaying) 
                {
                    continue;
                }
                _soundControllers[i].SetClip(clip);
                _soundControllers[i].PlaySound(positon);
                break;
            }
        }
    }

}

