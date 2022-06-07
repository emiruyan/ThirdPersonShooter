using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Controllers;
using ThirdPersonShooter.Abstracts.States;
using ThirdPersonShooter.Controllers;
using UnityEngine;

namespace ThirdPersonShooter.States.EnemyStates
{
    public class DeadState : IState
    { 
        IEnemyController _enemyController;
        float _currentTime = 0f;
        float _maxTime = 5f;
        
        public DeadState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
          

        }
        
        public void OnEnter()
        {
            Debug.Log($"{nameof(DeadState)} {nameof(OnEnter)}");
            _enemyController.Dead.DeadAction();
            _enemyController.Animation.DeadAnimation();
            _enemyController.transform.GetComponent<CapsuleCollider>().enabled = false;
        }
        public void OnExit()
        {
            Debug.Log($"{nameof(DeadState)} {nameof(OnExit)}");
        }
        public void Tick()
        {
         
            return;
         
        }

        public void TickFixed()
        {
         return;   
        }

        public void TickLate()
        {
            return;
        }
    }

}

