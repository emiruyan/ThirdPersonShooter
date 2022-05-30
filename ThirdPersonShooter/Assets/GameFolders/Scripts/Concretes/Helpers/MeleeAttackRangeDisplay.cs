using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace ThirdPersonShooter.Helpers
{
    public class MeleeAttackRangeDisplay : MonoBehaviour //bu scriptin amacı atak kısmının neye geldiğini bize gösterecek
    {
        [SerializeField] private float _radius = 1f;
        
        private void OnDrawGizmos()
        {
                    OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position,_radius);
        }
    }
}


