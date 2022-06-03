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
        }
        public void OnExit()
        {
            Debug.Log($"{nameof(DeadState)} {nameof(OnExit)}");
        }
        public void Tick()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _maxTime)
            {
                GameObject.Destroy(_enemyController.transform.gameObject);
            }
        }

        public void TickFixed()
        {
            
        }

        public void TickLate()
        {
            
        }
    }

}

