using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Combats;
using UnityEngine;
using UnityEngine.UI;

namespace ThirdPersonShooter.Uis
{
    public class DisplayHealth : MonoBehaviour
    { 
        Image _healthImage;

        private void Awake()
        {
            _healthImage = GetComponent<Image>();
        }

        private void OnEnable()
        {
            Health health = GetComponentInParent<Health>();
            health.OnTakeHit += HandleTakeHit;
        }
        
        private void HandleTakeHit(int currentHealth, int maxHealth)
        {
            _healthImage.fillAmount = Convert.ToSingle(currentHealth) / Convert.ToSingle(maxHealth);
            
        }
    }

}
    

